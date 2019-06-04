using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models
{
    public class AbandonedProductTypes
    {
        public ProductType ProductType { get; set; }

        public int Count { get; set; }
    }
}