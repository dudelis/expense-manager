using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System.Collections.Generic;

namespace ExpenseManager.Business.Interfaces
{
    public interface IAccountService : IServiceBase<Account, IAccountRepository>
    {
        List<Account> GetAllByAccountType(int AccountTypeId);
    }
}
