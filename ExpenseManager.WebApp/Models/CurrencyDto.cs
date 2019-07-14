using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class CurrencyDto
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<AccountDto> Accounts { get; set; }
        public ICollection<ExpenseDto> Expenses { get; set; }

        public CurrencyDto(Currency currency)
        {
            Code = currency.Code;
            Name = currency.Name;

            Accounts = AccountDto.Convert(currency.Accounts);
            Expenses = ExpenseDto.Convert(currency.Expenses);
        }
        public static ICollection<CurrencyDto> Convert (ICollection<Currency> currencies)
        {
            if (currencies == null)
                return null;
            return currencies.Select(x => new CurrencyDto(x)).ToList();
        }
    }
}
