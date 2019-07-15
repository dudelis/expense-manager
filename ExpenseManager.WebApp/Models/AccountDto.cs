using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class AccountDto: BaseEntityDto
    {
        [Required]
        public string Name { get; set; }
        public string IconCode { get; set; }

        [Required]
        [MaxLength(3, ErrorMessage = "Currency should not contain more than 3 characters")]
        [Display(Name="Currency")]
        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }

        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }

        public int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }

        public bool IncludeInTotals { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public AccountDto()
        {

        }

        public AccountDto(Account a)
        {
            Id = a.Id;
            CreatedOn = a.CreatedOn;
            UpdatedOn = a.UpdatedOn;
            Name = a.Name;
            IconCode = a.IconCode;
            CurrencyCode = a.CurrencyCode;
            Currency = a.Currency;
            Balance = a.Balance;
            BalanceDate = a.BalanceDate;
            AccountTypeId = a.AccountTypeId;
            AccountType = a.AccountType;
            IncludeInTotals = a.IncludeInTotals;
            Expenses = a.Expenses;
        }
        public static ICollection<AccountDto> Convert(ICollection<Account> accounts)
        {
            if (accounts == null)
                return null;
            return accounts.Select(x => new AccountDto(x)).ToList();

        }
    }
}
