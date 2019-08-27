using ExpenseManager.Auth.Concrete;
using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class ProfileConfiguration: BaseEntity, IProfileDependent
    {
        public int MonthStartDay { get; set; }
        public string DefaultCurrency { get; set; }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }

    }
}
