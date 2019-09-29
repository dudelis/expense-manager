using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class AccountTransferManager : BaseManager<AccountTransfer, IAccountTransferRepository>, IAccountTransferService
    {
        public AccountTransferManager(IAccountTransferRepository repository) : base(repository)
        {

        }

    }
}
