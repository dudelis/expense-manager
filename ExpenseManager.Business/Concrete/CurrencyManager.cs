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
        public List<Currency> GetAll()
        {
            return this._repository.Currency.GetList();
        }
    }
}
