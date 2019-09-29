using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpenseManager.Entities.Concrete
{
    public class Account : BaseEntity, IProfileDependent
    {
        public string Name { get; set; }
        public string IconCode { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }

        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }

        public bool IncludeInTotals { get; set; }

        public ICollection<AccountTransfer> SourceAccountTransfers { get; set; }
        public ICollection<AccountTransfer> DestinationAccountTransfers { get; set; }
        public ICollection<Income> Incomes { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }
    }
}
