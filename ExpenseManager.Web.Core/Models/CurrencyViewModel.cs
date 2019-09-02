using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Web.Core.Models
{
    public class CurrencyViewModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "String should not contain more than 3 characters")]
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
