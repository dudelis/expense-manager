using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class PayeeDto
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

        public ICollection<ExpenseDto> Expenses { get; set; }

        public PayeeDto(Payee payee)
        {
            Id = payee.Id;
            CreatedOn = payee.CreatedOn;
            UpdatedOn = payee.UpdatedOn;
            Name = payee.Name;
            AccountNumber = payee.AccountNumber;
            PhoneNumber = payee.PhoneNumber;
            WebSite = payee.WebSite;
            Notes = payee.Notes;
            Expenses = ExpenseDto.Convert(payee.Expenses);
        }

        public static ICollection<PayeeDto> Convert(ICollection<Payee> payees)
        {
            if (payees == null)
                return null;
            return payees.Select(x => new PayeeDto(x)).ToList();
        }

    }
}
