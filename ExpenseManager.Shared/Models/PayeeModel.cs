using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseManager.Shared.Models
{
    public class PayeeModel: BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

    }
}
