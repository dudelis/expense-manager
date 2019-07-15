using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class AccountDto: BaseEntityDto
    {
        public string Name { get; set; }
        public string IconCode { get; set; }

        public string CurrencyCode { get; set; }
        public virtual CurrencyDto Currency { get; set; }

        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }

        public int AccountTypeId { get; set; }
        public virtual AccountTypeDto AccountType { get; set; }

        public bool IncludeInTotals { get; set; }
        public virtual ICollection<ExpenseDto> Expenses { get; set; }

        public AccountDto(Account a)
        {
            Id = a.Id;
            CreatedOn = a.CreatedOn;
            UpdatedOn = a.UpdatedOn;
            Name = a.Name;
            IconCode = a.IconCode;
            CurrencyCode = a.CurrencyCode;
            Currency = new CurrencyDto(a.Currency);
            Balance = a.Balance;
            BalanceDate = a.BalanceDate;
            AccountTypeId = a.AccountTypeId;
            AccountType = new AccountTypeDto(a.AccountType);
            IncludeInTotals = a.IncludeInTotals;
            Expenses = ExpenseDto.Convert(a.Expenses);
        }
        public static ICollection<AccountDto> Convert(ICollection<Account> accounts)
        {
            if (accounts == null)
                return null;
            return accounts.Select(x => new AccountDto(x)).ToList();

        }
    }
}
