using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfCurrencyRepository: EfEntityRepositoryBase<Currency, ExpenseManagerDbContext>, ICurrencyRepository
    {
        public EfCurrencyRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
