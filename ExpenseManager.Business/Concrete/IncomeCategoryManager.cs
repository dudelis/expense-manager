using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class IncomeCategoryManager : BaseManager<IncomeCategory, IIncomeCategoryRepository>, IIncomeCategoryService
    {
        
        public IncomeCategoryManager(IIncomeCategoryRepository repository): base(repository)
        {
        }
        
    }
}
