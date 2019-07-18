using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class ExpenseCategoryManager : IExpenseCategoryService
    {
        private IRepositoryWrapper _repository;

        public ExpenseCategoryManager(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public void Create(ExpenseCategory entity)
        {
            _repository.ExpenseCategory.Create(entity);
        }

        public void Delete(ExpenseCategory entity)
        {
            _repository.ExpenseCategory.Delete(entity);

        }

        public List<ExpenseCategory> GetAll()
        {
            return _repository.ExpenseCategory.GetList();
        }

        public ExpenseCategory GetById(int id)
        {
            return _repository.ExpenseCategory.Get(p => p.Id == id);
        }

        public bool ItemExists(int id)
        {
            return _repository.ExpenseCategory.ItemExists(p => p.Id == id);
        }

        public void SaveChanges()
        {
            _repository.Save();
        }

        public void Update(ExpenseCategory entity)
        {
            _repository.ExpenseCategory.Update(entity);
        }
    }
}
