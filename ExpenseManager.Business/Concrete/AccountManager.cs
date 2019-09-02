using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Business.Concrete
{
    public class AccountManager : BaseManager<Account, IAccountRepository>, IAccountService
    {
        
        public AccountManager(IAccountRepository repository): base(repository)
        {
            
        }

        public List<Account> GetAllByAccountType(int accountTypeId)
        {
            return this.Repository.GetList(a => a.AccountTypeId == accountTypeId);
        }

    }
}
