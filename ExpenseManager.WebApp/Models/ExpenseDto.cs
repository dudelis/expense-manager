using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class ExpenseDto: BaseEntityDto
    {        
        [Required]
        public DateTime ExpenseDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public int? PayFromAccountId { get; set; }
        public AccountDto PayFromAccount { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public ExpenseCategoryDto Category { get; set; }
        [Required]
        public string CurrencyCode { get; set; }
        public CurrencyDto Currency { get; set; }

        public int? PayeeId { get; set; }
        public PayeeDto Payee { get; set; }

        public ExpenseDto(Expense e)
        {
            Id = e.Id;
            CreatedOn = e.CreatedOn;
            UpdatedOn = e.UpdatedOn;
            ExpenseDate = e.ExpenseDate;
            Amount = e.Amount;
            Notes = e.Notes;
            PayFromAccountId = e.PayFromAccountId;
            PayFromAccount = new AccountDto(e.PayFromAccount);
            CategoryId = e.CategoryId;
            Category = new ExpenseCategoryDto(e.Category);
            CurrencyCode = e.CurrencyCode;
            Currency = new CurrencyDto(e.Currency);
            PayeeId = e.PayeeId;
            Payee = new PayeeDto(e.Payee);
        }
        public static ICollection<ExpenseDto> Convert(ICollection<Expense> expenses)
        {
            if (expenses == null)
                return null;
            return expenses.Select(x => new ExpenseDto(x)).ToList();
        }
    }
}
