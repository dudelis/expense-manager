using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Models
{
    public class AccountTypeDto
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Required]
        [Display(Name = "Account Type Name")]
        public string Name { get; set; }

        public AccountTypeDto()
        {

        }
        public AccountTypeDto(AccountType source)
        {
            Id = source.Id;
            CreatedOn = source.CreatedOn;
            UpdatedOn = source.UpdatedOn;
            Name = source.Name;
        }
        public static IEnumerable<AccountTypeDto> Convert(IEnumerable<AccountType> types)
        {
            if (types == null)
                return null;
            return types.Select(x => new AccountTypeDto(x));
        }
    }
}
