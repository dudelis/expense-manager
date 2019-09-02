using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Interfaces
{
    public interface IAccountService: IServiceBase<Account, IAccountRepository>
    {
        List<Account> GetAllByAccountType(int AccountTypeId);
    }
}
