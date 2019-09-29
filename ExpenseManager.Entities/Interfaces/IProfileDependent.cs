using ExpenseManager.Entities.Concrete;
using System;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IProfileDependent
    {
        Guid ProfileId { get; }
        Profile Profile { get; }

        void SetProfileId(Guid id);
    }
}
