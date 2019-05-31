using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.ProductViewModels
{
    public class ProductTypesViewModel
    {
        public IEnumerable<GroupedProducts> GroupedProducts { get; set; }
    }
}
