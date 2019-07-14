using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private IRepositoryWrapper _repository;
        public CurrencyManager(IRepositoryWrapper repository)
        {
            this._repository = repository;
        }

        public void Create(Currency currency)
        {
            this._repository.Currency.Create(currency);
        }

        public void Delete(Currency currency)
        {
            this._repository.Currency.Delete(currency);
        }

        public List<Currency> GetAll()
        {
            return this._repository.Currency.GetList();
        }

        public Currency GetById(string code)
        {
            return this._repository.Currency.Get(x => x.Code == code);
        }

        public bool ItemExists(string code)
        {
            return this._repository.Currency.ItemExists(x => x.Code == code);
        }

        public void Update(Currency currency)
        {
            this._repository.Currency.Update(currency);
        }
    }
}
