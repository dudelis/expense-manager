using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class PayeeManager : BaseManager<Payee, IPayeeRepository>, IPayeeService
    {
        public PayeeManager(IPayeeRepository repository) : base(repository)
        {
        }
    }
}
