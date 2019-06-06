using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bangazon.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> AddOrder(int? id)
        {

            var user = await GetCurrentUserAsync();

            Order order;
            if (_context.Order.FirstOrDefault(x => x.UserId == user.Id && x.DateCompleted == null) == null)
            {
                order = new Order
                {
                    UserId = user.Id,
                    User = user
                };
                _context.Order.Add(order);
                _context.SaveChanges();
            }

            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = _context.Order.FirstOrDefault(x => x.UserId == user.Id && x.DateCompleted == null).OrderId,
                Order = _context.Order.FirstOrDefault(x => x.UserId == user.Id && x.DateCompleted == null),
                ProductId = _context.Product.FirstOrDefault(x => x.ProductId == id).ProductId,
                Product = _context.Product.FirstOrDefault(x => x.ProductId == id)
            };
            _context.OrderProduct.Add(orderProduct);
            _context.SaveChanges();

            TempData["notice"] = "Successfully registered";

            return RedirectToAction("Index", "Products");
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.PaymentType).Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.PaymentType)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [Authorize]
        public async Task<IActionResult> GetIncompleteOrders()
        {
            var applicationDbContext = _context.Order
                .Include(o => o.PaymentType)
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.PaymentTypeId == null);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Abandoned orders
        [Authorize]
        public async Task<IActionResult> GetAbandonedOrders()
        {
            // Find all products on open orders
            var openOrderProducts = _context.Product
               .Include(p => p.OrderProducts)
               .ThenInclude(op => op.Order)
               // Only want open orders. Check for any OrderProducts on incomplete orders
               .Where(p => p.OrderProducts.Any(op => op.Order.PaymentType == null))
               .Include(p => p.ProductType)
               ;

            var abandonedProductTypes = openOrderProducts
                .GroupBy(p => p.ProductTypeId,
                         p => p.ProductType,
                         (id, type) => new AbandonedProductTypes
                         {
                             ProductType = type.First(),
                             Count = type.Count()
                         })
                .OrderByDescending(pt => pt.Count)
                .Take(5)
                ;

            return View(abandonedProductTypes);
        }

        public async Task<IActionResult> GetOrderHistory()
        {
            
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.Order
                .Include(o => o.PaymentType)
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.PaymentTypeId != null && o.UserId == user.Id );

            return View(await applicationDbContext.ToListAsync());
        }


        [Authorize]
        // GET: Multiple orders
        public async Task<IActionResult> GetMultipleOrder()
        {
            var usersWithNull = _context.ApplicationUsers.Include(o => o.Orders).Where(g => g.Orders.Any(h => h.PaymentType == null)).ToList();
            var usersWithMultipleOrders = usersWithNull.Where(u => u.Orders.Count() >= 2);
            return View(usersWithMultipleOrders);
        }

        [Authorize]
        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentType, "PaymentTypeId", "AccountNumber");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,DateCreated,DateCompleted,UserId,PaymentTypeId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentType, "PaymentTypeId", "AccountNumber", order.PaymentTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize]
        public async Task<IActionResult> ViewCart()
        {

            var user = await GetCurrentUserAsync();

            //Order order;
            //if (_context.Order.FirstOrDefault(x => x.UserId == user.Id && x.DateCompleted == null) == null)
            //{
                
            //}

            var order = _context.Order
               .Include(o => o.OrderProducts)
               .ThenInclude(x => x.Product)
               .FirstOrDefault(x => x.UserId == user.Id && x.DateCompleted == null);

            var userPayments = _context.PaymentType.Where(pt => pt.UserId == user.Id);

            if (order == null)
            {
                return NotFound();
            }
            ViewData["PaymentTypeId"] = new SelectList(userPayments, "PaymentTypeId", "AccountNumber", order.PaymentTypeId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewCart([Bind("OrderId,DateCreated,DateCompleted,UserId,PaymentTypeId")] Order order)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            var user = await GetCurrentUserAsync();
            order.User = user;
            order.UserId = user.Id;

            order = _context.Order
               .Include(o => o.OrderProducts)
               .ThenInclude(x => x.Product)
               .FirstOrDefault(x => x.UserId == user.Id && x.DateCompleted == null);


            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var item in order.OrderProducts)
                    {
                        item.Product.Quantity--;
                        _context.Update(item.Product);
                    }
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Products");
            }
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentType, "PaymentTypeId", "AccountNumber", order.PaymentTypeId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", order.UserId);
            return View(order);
        }


        public async Task<IActionResult> CancelOrder(int? id)
        {
            var user = await GetCurrentUserAsync();
            var activeOrder = await _context.Order
                .Include(x => x.OrderProducts).
                FirstOrDefaultAsync(x => x.UserId == user.Id && x.DateCompleted == null);

         foreach( var item in activeOrder.OrderProducts)
            {
                _context.OrderProduct.Remove(item);
            }

            _context.Order.Remove(activeOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        // GET: Orders/Delete/5
        public async Task<IActionResult> DeleteProductFromOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("DeleteProductFromOrder")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var user = await GetCurrentUserAsync();

            var activeOrder = await _context.Order.FirstOrDefaultAsync(x => x.UserId == user.Id && x.DateCompleted == null);

            var orderProduct = await _context.OrderProduct.FirstOrDefaultAsync(x => x.OrderId == activeOrder.OrderId && x.ProductId == id);


            _context.OrderProduct.Remove(orderProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}