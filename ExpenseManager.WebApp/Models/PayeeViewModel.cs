using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class PayeeViewModel: BaseViewModel
    {
        [Required(ErrorMessage ="Name is a required field")]
        public string Name { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

        public ICollection<Expense> Expenses { get; set; }
        public PayeeViewModel()
        {

        }
        public PayeeViewModel(Payee payee)
        {
            Id = payee.Id;
            CreatedTime = payee.CreatedTime;
            ModifiedTime = payee.ModifiedTime;
            Name = payee.Name;
            AccountNumber = payee.AccountNumber;
            PhoneNumber = payee.PhoneNumber;
            WebSite = payee.WebSite;
            Notes = payee.Notes;
            Expenses = payee.Expenses;
        }

        public static ICollection<PayeeViewModel> Convert(ICollection<Payee> payees)
        {
            if (payees == null)
                return null;
            return payees.Select(x => new PayeeViewModel(x)).ToList();
        }

    }
}
