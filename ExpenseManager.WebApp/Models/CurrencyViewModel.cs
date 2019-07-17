using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class CurrencyViewModel
    {
        [Required]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Expense> Expenses { get; set; }

        public CurrencyViewModel(){}
        public CurrencyViewModel(Currency currency)
        {
            if (currency != null)
            {
                Code = currency.Code;
                Name = currency.Name;

                Accounts = currency.Accounts;
                Expenses = currency.Expenses;
            }
            
        }
        public static ICollection<CurrencyViewModel> Convert (ICollection<Currency> currencies)
        {
            if (currencies == null)
                return null;
            return currencies.Select(x => new CurrencyViewModel(x)).ToList();
        }
    }
}
