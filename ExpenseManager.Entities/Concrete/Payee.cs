using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class Payee : BaseEntity, IProfileDependent
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }

        public ICollection<Expense> Expenses { get; set; }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }
    }
}
