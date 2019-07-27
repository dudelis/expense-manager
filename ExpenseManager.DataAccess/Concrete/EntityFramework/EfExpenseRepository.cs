using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseRepository: EfEntityRepositoryBase<Expense, int, ExpenseManagerDbContext>, IExpenseRepository
    {
        public EfExpenseRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
