using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseRepository _repository;

        public ExpenseManager(IExpenseRepository repository)
        {
            this._repository = repository;
        }
        public void Create(Expense entity)
        {
            this._repository.Create(entity);
        }

        public void Delete(Expense entity)
        {
            this._repository.Delete(entity);
        }

        public List<Expense> GetAll()
        {
            return this._repository.GetList();
        }

        public List<Expense> GetByAccount(int payFromAccountId)
        {
            return this._repository.GetList(e => e.PayFromAccountId == payFromAccountId);
        }

        public List<Expense> GetByCategory(int expenseCategoryId)
        {
            return this._repository.GetList(e => e.CategoryId == expenseCategoryId);
        }

        public List<Expense> GetByDate(DateTime epenseDate)
        {
            throw new NotImplementedException();
        }

        public Expense GetById(int id)
        {
            return this._repository.Get(e => e.Id == id);
        }

        public List<Expense> GetByPayee(int payeeId)
        {
            return this._repository.GetList(e => e.PayeeId == payeeId);
        }

        public void Update(Expense entity)
        {
            this._repository.Update(entity);
        }
    }
}
