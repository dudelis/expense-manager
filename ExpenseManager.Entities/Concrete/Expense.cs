using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class Expense : BaseEntity, IProfileDependent
    {
        public string Name { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }

        public int? PayFromAccountId { get; set; }
        public virtual Account PayFromAccount { get; set; }


        public int? CategoryId { get; set; }
        public virtual ExpenseCategory Category { get; set; }

        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }

        public int? PayeeId { get; set; }
        public virtual Payee Payee { get; set; }


    }
}
