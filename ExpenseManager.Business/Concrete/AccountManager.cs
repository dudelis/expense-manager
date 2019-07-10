using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private IRepositoryWrapper _repository;
        public AccountManager(IRepositoryWrapper repository)
        {
            this._repository = repository;
        }

        public void Create(Account account)
        {
            this._repository.Account.Create(account);
        }

        public void Delete(Account account)
        {
            this._repository.Account.Delete(account);
        }

        public List<Account> GetAll()
        {
            return this._repository.Account.GetList();
        }

        public void Update(Account account)
        {
            this._repository.Account.Update(account);
        }

        public List<Account> GetAllByAccountType(int accountTypeId)
        {
            return this._repository.Account.GetList(a => a.AccountTypeId == accountTypeId);
        }

        public Account GetById(int accountId)
        {
            return this._repository.Account.Get(a => a.Id == accountId);
        }

        public void SaveChanges()
        {
            this._repository.Save();
        }

        public bool ItemExists(int id)
        {
            return this._repository.Account.ItemExists(a => a.Id == id);
        }
    }
}
