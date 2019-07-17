using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class AccountTypeDto: BaseViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public ICollection<AccountViewModel> Accounts { get; set; }

        public AccountTypeDto(){}

        public AccountTypeDto(AccountType source)
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
        public static ICollection<AccountTypeDto> Convert(ICollection<AccountType> types)
        {
            if (types == null)
                return null;
            return types.Select(x => new AccountTypeDto(x)).ToList();
        }
    }
}
