using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Interfaces
{
    public interface ICurrencyService
    {
        List<Currency> GetAll();
    }
}
