using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class AccountType : BaseEntity<int>
    {
        public string Name { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; }

    }
}
