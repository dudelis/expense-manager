using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class CurrencyManager : BaseManager<Currency, ICurrencyRepository>, ICurrencyService
    {
        public CurrencyManager(ICurrencyRepository repository) : base(repository)
        {
        }
    }
}
