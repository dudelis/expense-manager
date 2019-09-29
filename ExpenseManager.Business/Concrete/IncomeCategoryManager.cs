using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class IncomeCategoryManager : BaseManager<IncomeCategory, IIncomeCategoryRepository>, IIncomeCategoryService
    {

        public IncomeCategoryManager(IIncomeCategoryRepository repository) : base(repository)
        {
        }

    }
}
