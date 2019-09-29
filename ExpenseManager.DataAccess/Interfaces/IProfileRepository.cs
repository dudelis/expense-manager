using ExpenseManager.Entities.Concrete;
using ExpenseManager.Entities.Interfaces;
using System;

namespace ExpenseManager.DataAccess.Interfaces
{
    public interface IProfileRepository : IEntityRepository<Profile, Guid>
    {
    }
}
