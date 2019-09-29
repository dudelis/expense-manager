using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfAccountTransferRepository : EfEntityRepositoryBase<AccountTransfer, ExpenseManagerDbContext>, IAccountTransferRepository
    {
        public EfAccountTransferRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
