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
    public class AccountTransferManager : BaseManager<AccountTransfer, IAccountTransferRepository>, IAccountTransferService
    {
        public AccountTransferManager(IAccountTransferRepository repository): base(repository)
        {
            
        }

    }
}
