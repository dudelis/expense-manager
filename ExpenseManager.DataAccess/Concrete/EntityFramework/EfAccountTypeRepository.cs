using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfAccountTypeRepository: EfEntityRepositoryBase<AccountType, int, ExpenseManagerDbContext>, IAccountTypeRepository
    {
        public EfAccountTypeRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
