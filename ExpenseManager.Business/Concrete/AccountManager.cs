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
        private IAccountRepository _repository;
        public AccountManager(IAccountRepository repository)
        {
            this._repository = repository;
        }

        public void Create(Account account)
        {
            this._repository.Create(account);
        }

        public void Delete(Account account)
        {
            this._repository.Delete(account);
        }

        public List<Account> GetAll()
        {
            return this._repository.GetList();
        }

        public void Update(Account account)
        {
            this._repository.Update(account);
        }

        public List<Account> GetAllByAccountType(int accountTypeId)
        {
            return this._repository.GetList(a => a.AccountTypeId == accountTypeId);
        }

        public Account GetById(int accountId)
        {
            return this._repository.Get(a => a.Id == accountId);
        }
    }
}
