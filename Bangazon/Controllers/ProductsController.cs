using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Bangazon.Models.ProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Bangazon.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, 
                    UserManager<ApplicationUser> userManager, 
                    IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //get's and displays the last 20 products 
            var applicationDbContext = _context.Product.Include(p => p.ProductType).Include(p => p.User).OrderByDescending(a => a.DateCreated).Take(20);
            
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> SearchByCity(string Search)
        {
            List<Product> productsMatched = await _context.Product.Include(p => p.ProductType).Include(p => p.User).Where(product => product.City.Contains(Search)).ToListAsync();
            return View(productsMatched);
        }

        [Authorize]
        public async Task<IActionResult> Search(string Search)
        {
            List<Product> productsMatched = await _context.Product.Include(p => p.ProductType).Include(p => p.User).Where(product => product.Title.Contains(Search)).ToListAsync();
            return View(productsMatched);
        }

        

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Types()
        {
            List<GroupedProducts> model = new List<GroupedProducts>();
          
            model = await (
                from t in _context.ProductType
                join p in _context.Product
                on t.ProductTypeId equals p.ProductTypeId
                group new { t, p } by new { t.ProductTypeId, t.Label } into grouped
                select new GroupedProducts
                {
                    TypeId = grouped.Key.ProductTypeId,
                    TypeName = grouped.Key.Label,
                    ProductCount = grouped.Select(x => x.p.ProductId).Count(),
                    Products = grouped.Select(x => x.p).Take(3)
                }).ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> GetProductsByCategory(int id)
        {

            var products = _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .Where(p => p.ProductTypeId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(await products.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> GetUserProducts()
        {
            var user = await GetCurrentUserAsync();

            var products = _context.Product
                .Include(p => p.ProductType)
                .Where(p => p.UserId == user.Id);

            return View(await products.ToListAsync());
        }

        [Authorize]
        // GET: Products/Create
        public IActionResult Create()
        {
            UploadImageViewModel viewproduct = new UploadImageViewModel();
            viewproduct.Product = new Product();
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label");
            return View(viewproduct);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UploadImageViewModel viewproduct)
        {

            // Remove the user from the model validation because it is not information posted in the form
            ModelState.Remove("UserId");
            ModelState.Remove("product.UserId");

            // add current dateTime
            viewproduct.Product.DateCreated = DateTime.Now;

            // add current userId
            var user = await GetCurrentUserAsync();
            viewproduct.Product.UserId = user.Id;

            // price can't exceed $10,000
            var userEnteredPrice = viewproduct.Product.Price;
            var maxPrice = 10001;

            if(maxPrice < userEnteredPrice)
            {
            ViewBag.Message = "Price can't exceed $10,000.";
            return View(viewproduct);
            }
            else {

            if (ModelState.IsValid)
            {

                if (viewproduct.ImageFile != null)
                {
                    // don't rely on or trust the FileName property without validation
                    //**Warning**: The following code uses `GetTempFileName`, which throws
                    // an `IOException` if more than 65535 files are created without 
                    // deleting previous temporary files. A real app should either delete
                    // temporary files or use `GetTempPath` and `GetRandomFileName` 
                    // to create temporary file names.

                    var fileName = Path.GetFileName(viewproduct.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewproduct.ImageFile.CopyToAsync(stream);
                        // validate file, then move to CDN or public folder
                    }

                    viewproduct.Product.ImagePath = viewproduct.ImageFile.FileName;
                }
                _context.Add(viewproduct.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", viewproduct.Product.ProductTypeId);
            return View(viewproduct);
            }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,DateCreated,Description,Title,Price,Quantity,UserId,City,ImagePath,ProductTypeId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.UserId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductType)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetUserProducts));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
