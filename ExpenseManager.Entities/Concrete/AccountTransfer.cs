using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class AccountTransfer: BaseEntity, IProfileDependent
    {
        public int SourceAccountId { get; set; }
        public Account SourceAccount { get; set; }
        public int DestinationAccountId { get; set; }
        public Account DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime TransferDate { get; set; }
        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }
    }
}
