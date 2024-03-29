﻿using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpenseManager.Entities.Concrete
{
    public class ExpenseCategory : BaseEntity, IProfileDependent
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public virtual ExpenseCategory ParentCategory { get; set; }

        public virtual ICollection<ExpenseCategory> ChildCategories { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }
    }
}
