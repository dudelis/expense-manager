using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfIncomeRepository : EfEntityRepositoryBase<Income, ExpenseManagerDbContext>, IIncomeRepository
    {
        public EfIncomeRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
