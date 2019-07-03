using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class ExpenseCategory : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ExpenseCategory ParentCategory { get; set; }
        public virtual ICollection<ExpenseCategory> ChildCategories { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
