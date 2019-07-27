using ExpenseManager.Entities.Concrete;
using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Interfaces
{
    public interface IAccountRepository: IEntityRepository<Account>
    {
    }
}
