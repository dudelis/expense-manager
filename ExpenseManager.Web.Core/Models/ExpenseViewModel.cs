using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExpenseManager.Web.Core.Models
{
    public class ExpenseViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Date")]
        public DateTime ExpenseDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        [Required]
        [Display(Name = "Pay from")]
        public int? PayFromAccountId { get; set; }
        public Account PayFromAccount { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public ExpenseCategory Category { get; set; }
        [Required]
        [Display(Name = "Currency")]
        public string CurrencyCode { get; set; }
        public Currency Currency { get; set; }

        [Display(Name = "Payee")]
        public int? PayeeId { get; set; }
        public Payee Payee { get; set; }

        public ICollection<Account> ListOfAccounts { get; set; }
        public ICollection<ExpenseCategory> ListOfCategories { get; set; }
        public ICollection<Currency> ListOfCurrencies { get; set; }
        public ICollection<Payee> ListOfPayees { get; set; }


        public ExpenseViewModel()
        {

        }

        public ExpenseViewModel(Expense e)
        {
            Id = e.Id;
            CreatedTime = e.CreatedTime;
            ModifiedTime = e.ModifiedTime;
            ExpenseDate = e.ExpenseDate;
            Amount = e.Amount;
            Notes = e.Notes;
            PayFromAccountId = e.PayFromAccountId;
            PayFromAccount = e.PayFromAccount;
            CategoryId = e.CategoryId;
            Category = e.Category;
            CurrencyCode = e.CurrencyCode;
            PayeeId = e.PayeeId;
            Payee = e.Payee;
        }
        public static ICollection<ExpenseViewModel> Convert(ICollection<Expense> expenses)
        {
            if (expenses == null)
                return null;
            return expenses.Select(x => new ExpenseViewModel(x)).ToList();
        }
    }
}
