using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IProfileDependent
    {
        Guid ProfileId { get; }
        Profile Profile { get; }

        void SetProfileId(Guid id);
    }
}
