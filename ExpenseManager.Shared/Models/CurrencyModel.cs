using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Shared.Models
{
    public class CurrencyModel: BaseModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "Code should not contain more than 3 characters")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Symbol { get; set; }

        public bool Selected { get; set; }
    }
}
