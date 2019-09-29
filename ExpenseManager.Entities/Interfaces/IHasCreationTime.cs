using System;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IHasCreationTime
    {
        DateTime CreatedTime { get; set; }
    }
}
