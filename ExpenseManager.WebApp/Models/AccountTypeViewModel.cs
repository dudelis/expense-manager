using ExpenseManager.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class AccountTypeViewModel: BaseViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [Remote(action: "VerifyNameUnique", controller: "AccountType")]
        public string Name { get; set; }
        public ICollection<AccountViewModel> Accounts { get; set; }

        public AccountTypeViewModel(){}

        public AccountTypeViewModel(AccountType source)
        {
            if (source != null)
            {
                Id = source.Id;
                CreatedOn = source.CreatedOn;
                UpdatedOn = source.UpdatedOn;
                Name = source.Name;
                Accounts = AccountViewModel.Convert(source.Accounts);
            }
        }
        public static ICollection<AccountTypeViewModel> Convert(ICollection<AccountType> types)
        {
            if (types == null)
                return null;
            return types.Select(x => new AccountTypeViewModel(x)).ToList();
        }
    }
}
