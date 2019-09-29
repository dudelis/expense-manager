using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseRepository : EfEntityRepositoryBase<Expense, ExpenseManagerDbContext>, IExpenseRepository
    {
        public EfExpenseRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
