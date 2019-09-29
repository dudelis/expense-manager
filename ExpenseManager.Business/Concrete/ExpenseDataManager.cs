using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ExpenseManager.Business.Concrete
{
    public class ExpenseDataManager : BaseManager<Expense, IExpenseRepository>, IExpenseService
    {

        public ExpenseDataManager(IExpenseRepository repository) : base(repository)
        {
        }


        public List<Expense> GetByAccount(int payFromAccountId)
        {
            return this.Repository.GetList(e => e.PayFromAccountId == payFromAccountId);
        }

        public List<Expense> GetByCategory(int expenseCategoryId)
        {
            return this.Repository.GetList(e => e.CategoryId == expenseCategoryId);
        }

        public List<Expense> GetExpenseForMonth(DateTime expenseDate)
        {
            return this.Repository.GetList(e => e.ExpenseDate.Year == expenseDate.Year && e.ExpenseDate.Month == expenseDate.Month);
        }

        public List<Expense> GetByPayee(int payeeId)
        {
            return this.Repository.GetList(e => e.PayeeId == payeeId);
        }
    }
}
