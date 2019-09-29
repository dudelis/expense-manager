using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfPayeeRepository : EfEntityRepositoryBase<Payee, ExpenseManagerDbContext>, IPayeeRepository
    {
        public EfPayeeRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
