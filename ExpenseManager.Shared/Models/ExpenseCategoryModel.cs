using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseManager.Shared.Models
{
    public class ExpenseCategoryModel: BaseModel
    {
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
