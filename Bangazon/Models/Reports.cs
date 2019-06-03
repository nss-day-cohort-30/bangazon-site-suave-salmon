using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models
{
    public class Reports
    {
        [Key]
        public int ReportsId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string Last Name { get; set; }
    }
}
