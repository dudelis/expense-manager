using System;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IHasModificationTime
    {
        DateTime ModifiedTime { get; set; }
    }
}
