using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfUserSettingsRepository: EfEntityRepositoryBase<UserSettings, ExpenseManagerDbContext>, IUserSettingsRepository
    {
        public EfUserSettingsRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
