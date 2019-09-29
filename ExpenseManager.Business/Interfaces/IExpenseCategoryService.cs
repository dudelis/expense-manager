using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Interfaces
{
    public interface IExpenseCategoryService : IServiceBase<ExpenseCategory, IExpenseCategoryRepository>
    {

    }
}
