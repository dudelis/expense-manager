using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfPayeeRepository: EfEntityRepositoryBase<Payee, int, ExpenseManagerDbContext>, IPayeeRepository
    {
        public EfPayeeRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
