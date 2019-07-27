using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class AccountViewModel: BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        public string IconCode { get; set; }

        [Required]
        [MaxLength(3)]
        [Display(Name="Currency")]
        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }
        
        public decimal Balance { get; set; }
        [Display(Name = "As of")]
        public DateTime BalanceDate { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int? AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }

        [Display(Name = "Include in Home page totals")]
        public bool IncludeInTotals { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public ICollection<Currency> ListOfCurrencies { get; set; }
        public ICollection<AccountType> ListOfAccountTypes { get; set; }


        public AccountViewModel(){}

        public AccountViewModel(Account a)
        {
            Id = a.Id;
            CreatedTime = a.CreatedTime;
            ModifiedTime = a.ModifiedTime;
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
        public static ICollection<AccountViewModel> Convert(ICollection<Account> accounts)
        {
            if (accounts == null)
                return null;
            return accounts.Select(x => new AccountViewModel(x)).ToList();

        }
    }
}
