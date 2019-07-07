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
        private IAccountTypeRepository _repository;

        public AccountTypeManager(IAccountTypeRepository repository)
        {
            this._repository = repository;
        }
        public void Create(AccountType entity)
        {
            this._repository.Create(entity);
        }

        public void Delete(AccountType entity)
        {
            this._repository.Delete(entity);
        }

        public List<AccountType> GetAll()
        {
            return this._repository.GetList();
        }

        public AccountType GetById(int id)
        {
            return this._repository.Get(e => e.Id == id);
        }

        public void Update(AccountType entity)
        {
            this._repository.Update(entity);
        }
    }
}
