using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class Account : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string IconCode { get; set; }

        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }

        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }

        public int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }

        public bool IncludeInTotals { get; set; }


        public virtual ICollection<Expense> Expenses { get; set; }


    }
}
