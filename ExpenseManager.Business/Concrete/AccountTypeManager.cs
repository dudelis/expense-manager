using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class AccountTypeManager : BaseManager<AccountType, IAccountTypeRepository>, IAccountTypeService
    {
        public AccountTypeManager(IAccountTypeRepository repository) : base(repository)
        {

        }
    }
}
