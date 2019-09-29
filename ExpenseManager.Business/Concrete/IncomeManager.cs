using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class IncomeManager : BaseManager<Income, IIncomeRepository>, IIncomeService
    {

        public IncomeManager(IIncomeRepository repository) : base(repository)
        {
        }

    }
}
