using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IHasCreationTime
    {
        DateTime CreatedTime { get; set;  }
    }
}
