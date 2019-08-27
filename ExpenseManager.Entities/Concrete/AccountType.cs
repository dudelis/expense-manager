using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class AccountType : BaseEntity, IProfileDependent
    {
        public string Name { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }

    }
}
