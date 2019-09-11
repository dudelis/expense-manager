using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class Income : BaseEntity, IProfileDependent
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public IncomeCategory Category { get; set; }
        public DateTime IncomeDate { get; set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
        public string Notes { get; set; }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }
    }
}
