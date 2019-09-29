using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class ExpenseCategoryManager : BaseManager<ExpenseCategory, IExpenseCategoryRepository>, IExpenseCategoryService
    {
        public ExpenseCategoryManager(IExpenseCategoryRepository repository) : base(repository)
        {
        }
    }
}
