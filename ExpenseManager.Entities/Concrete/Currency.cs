using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class Currency : IEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
