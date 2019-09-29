using System;

namespace ExpenseManager.Entities.Concrete
{
    public class ProfileConfiguration : BaseEntity
    {
        public int MonthStartDay { get; set; }
        public string DefaultCurrency { get; set; }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

    }
}
