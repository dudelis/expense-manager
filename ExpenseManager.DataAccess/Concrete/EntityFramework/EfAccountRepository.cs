using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfAccountRepository : EfEntityRepositoryBase<Account, ExpenseManagerDbContext>, IAccountRepository
    {
        public EfAccountRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
