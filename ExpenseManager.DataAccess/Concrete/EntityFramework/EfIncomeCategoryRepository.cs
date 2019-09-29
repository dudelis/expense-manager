using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfIncomeCategoryRepository : EfEntityRepositoryBase<IncomeCategory, ExpenseManagerDbContext>, IIncomeCategoryRepository
    {
        public EfIncomeCategoryRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
