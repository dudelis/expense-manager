using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfUserSettingsRepository : EfEntityRepositoryBase<UserSettings, ExpenseManagerDbContext>, IUserSettingsRepository
    {
        public EfUserSettingsRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
