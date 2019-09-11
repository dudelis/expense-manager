using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfIncomeCategoryRepository: EfEntityRepositoryBase<IncomeCategory, ExpenseManagerDbContext>, IIncomeCategoryRepository
    {
        public EfIncomeCategoryRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
