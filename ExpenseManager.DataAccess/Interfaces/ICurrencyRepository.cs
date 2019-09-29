using ExpenseManager.Entities.Concrete;
using ExpenseManager.Entities.Interfaces;

namespace ExpenseManager.DataAccess.Interfaces
{
    public interface ICurrencyRepository : IEntityRepository<Currency>
    {
    }
}
