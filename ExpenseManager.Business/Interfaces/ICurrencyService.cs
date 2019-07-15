using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Interfaces
{
    public interface ICurrencyService
    {
        List<Currency> GetAll();
        Currency GetById(string code);
        void Create(Currency currency);
        void Update(Currency currency);
        void Delete(Currency currency);
        bool ItemExists(string code);
        void SaveChanges();
    }
}
