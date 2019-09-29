using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfProfileRepository : EfEntityRepositoryBase<Profile, Guid, ExpenseManagerDbContext>, IProfileRepository
    {
        public EfProfileRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
