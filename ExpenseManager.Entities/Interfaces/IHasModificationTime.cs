using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IHasModificationTime
    {
        DateTime ModifiedTime{ get; set; }
    }
}
