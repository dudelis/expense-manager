using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class Currency : BaseEntity<string>
    {
        public string Name { get; set; }
    }
}
