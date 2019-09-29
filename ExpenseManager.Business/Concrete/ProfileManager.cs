using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;

namespace ExpenseManager.Business.Concrete
{
    public class ProfileManager : BaseManager<Profile, Guid, IProfileRepository>, IProfileService
    {
        public ProfileManager(IProfileRepository repository) : base(repository)
        {
        }
    }
}
