using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class ExpenseDto: BaseViewModel
    {        
        [Required]
        public DateTime ExpenseDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public int? PayFromAccountId { get; set; }
        public AccountViewModel PayFromAccount { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public ExpenseCategoryDto Category { get; set; }
        [Required]
        public string CurrencyCode { get; set; }
        public CurrencyViewModel Currency { get; set; }

        public int? PayeeId { get; set; }
        public PayeeDto Payee { get; set; }

        public ExpenseDto()
        {

        }

        public ExpenseDto(Expense e)
        {
            if (e != null)
            {
                Id = e.Id;
                CreatedOn = e.CreatedOn;
                UpdatedOn = e.UpdatedOn;
                ExpenseDate = e.ExpenseDate;
                Amount = e.Amount;
                Notes = e.Notes;
                PayFromAccountId = e.PayFromAccountId;
                PayFromAccount = new AccountViewModel(e.PayFromAccount);
                CategoryId = e.CategoryId;
                Category = new ExpenseCategoryDto(e.Category);
                CurrencyCode = e.CurrencyCode;
                Currency = new CurrencyViewModel(e.Currency);
                PayeeId = e.PayeeId;
                Payee = new PayeeDto(e.Payee);
            }
        }
        public static ICollection<ExpenseDto> Convert(ICollection<Expense> expenses)
        {
            if (expenses == null)
                return null;
            return expenses.Select(x => new ExpenseDto(x)).ToList();
        }
    }
}
