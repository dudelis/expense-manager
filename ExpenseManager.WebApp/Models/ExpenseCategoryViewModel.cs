﻿using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class ExpenseCategoryViewModel: BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Display(Name = "Parent Category")]
        public int? ParentCategoryId { get; set; }
        public ExpenseCategory ParentCategory { get; set; }

        public ICollection<ExpenseCategory> ChildCategories { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public ICollection<ExpenseCategory> ListOfExpenseCategories { get; set; }

        public ExpenseCategoryViewModel()
        {

        }
        public ExpenseCategoryViewModel(ExpenseCategory category)
        {
            Id = category.Id;
            CreatedOn = category.CreatedOn;
            UpdatedOn = category.UpdatedOn;
            Name = category.Name;
            ParentCategoryId = category.ParentCategoryId;
            ParentCategory = category.ParentCategory;

            ChildCategories = category.ChildCategories;
            Expenses = category.Expenses;
        }

        public static ICollection<ExpenseCategoryViewModel> Convert(ICollection<ExpenseCategory> categories)
        {
            if (categories == null) return null;

            return categories.Select(x => new ExpenseCategoryViewModel(x)).ToList();
        }
    }
}