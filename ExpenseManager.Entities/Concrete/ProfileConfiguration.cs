using ExpenseManager.Auth.Concrete;
using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class ProfileConfiguration: BaseEntity
    {
        public int MonthStartDay { get; set; }
        public string DefaultCurrency { get; set; }
        
    }
}
