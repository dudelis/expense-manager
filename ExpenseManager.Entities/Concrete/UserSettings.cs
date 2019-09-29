using ExpenseManager.Entities.Interfaces;
using System;

namespace ExpenseManager.Entities.Concrete
{
    public class UserSettings : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Guid DefaultProfileId { get; set; }
        public Profile DefaultProfile { get; set; }
        public int MonthStartDay { get; set; }
        public string DefaultCurrency { get; set; }
    }
}
