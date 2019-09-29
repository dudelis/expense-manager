using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseCategoryRepository : EfEntityRepositoryBase<ExpenseCategory, ExpenseManagerDbContext>, IExpenseCategoryRepository
    {
        public EfExpenseCategoryRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
