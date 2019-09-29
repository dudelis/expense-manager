using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Shared.Models
{
    public class ExpenseCategoryModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}
