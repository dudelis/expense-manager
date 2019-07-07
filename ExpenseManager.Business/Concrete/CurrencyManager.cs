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
        private ICurrencyRepository _repository;
        public CurrencyManager(ICurrencyRepository repository)
        {
            this._repository = repository;
        }
        public List<Currency> GetAll()
        {
            return this._repository.GetList();
        }
    }
}
