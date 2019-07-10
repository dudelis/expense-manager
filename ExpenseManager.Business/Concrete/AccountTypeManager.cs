using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class AccountTypeManager : IAccountTypeService
    {
        private IRepositoryWrapper _repository;

        public AccountTypeManager(IRepositoryWrapper repository)
        {
            this._repository = repository;
        }
        public void Create(AccountType entity)
        {
            this._repository.AccountType.Create(entity);
        }

        public void Delete(AccountType entity)
        {
            this._repository.AccountType.Delete(entity);
        }

        public List<AccountType> GetAll()
        {
            return this._repository.AccountType.GetList();
        }

        public AccountType GetById(int id)
        {
            return this._repository.AccountType.Get(e => e.Id == id);
        }

        public void Update(AccountType entity)
        {
            this._repository.AccountType.Update(entity);
        }
    }
}
