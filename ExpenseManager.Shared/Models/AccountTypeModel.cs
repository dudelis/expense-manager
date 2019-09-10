using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseManager.Shared.Models
{
    public class AccountTypeModel: BaseModel
    {
        [Required]
        public string Name { get; set; }

    }
}
