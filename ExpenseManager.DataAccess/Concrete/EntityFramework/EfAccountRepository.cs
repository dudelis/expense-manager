using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfAccountRepository: EfEntityRepositoryBase<Account, int, ExpenseManagerDbContext>, IAccountRepository
    {
        public EfAccountRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
