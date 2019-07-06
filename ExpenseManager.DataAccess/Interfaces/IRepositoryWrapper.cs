﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get;  }
        IAccountRepository AccountType { get; }
        ICurrencyRepository Currency { get; }
        IExpenseRepository Expense { get; }
        IExpenseCategoryRepository ExpenseCategory { get; }
        IPayeeRepository Payee { get; }
        void Save();
    }
}
