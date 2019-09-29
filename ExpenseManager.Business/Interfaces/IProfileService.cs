using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;

namespace ExpenseManager.Business.Interfaces
{
    public interface IProfileService : IServiceBase<Profile, Guid, IProfileRepository>
    {
    }
}
