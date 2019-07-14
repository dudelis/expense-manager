using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class ExpenseCategoryDto
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? ParentCategoryId { get; set; }
        public ExpenseCategoryDto ParentCategory { get; set; }

        public ICollection<ExpenseCategoryDto> ChildCategories { get; set; }
        public ICollection<ExpenseDto> Expenses { get; set; }

        public ExpenseCategoryDto(ExpenseCategory category)
        {
            Id = category.Id;
            CreatedOn = category.CreatedOn;
            UpdatedOn = category.UpdatedOn;
            ParentCategoryId = category.ParentCategoryId;
            ParentCategory = new ExpenseCategoryDto(category.ParentCategory);

            ChildCategories = ExpenseCategoryDto.Convert(category.ChildCategories);
            Expenses = ExpenseDto.Convert(category.Expenses);
        }

        public static ICollection<ExpenseCategoryDto> Convert(ICollection<ExpenseCategory> categories)
        {
            if (categories == null) return null;

            return categories.Select(x => new ExpenseCategoryDto(x)).ToList();
        }
    }
}
