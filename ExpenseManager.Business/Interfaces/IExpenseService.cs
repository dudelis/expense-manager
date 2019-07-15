﻿using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Interfaces
{
    public interface IExpenseService: IServiceBase<Expense>
    {
        List<Expense> GetByExpenseDate(DateTime epenseDate);
        List<Expense> GetByAccount(int payFromAccountId);
        List<Expense> GetByCategory(int expenseCategoryId);
        List<Expense> GetByPayee(int payeeId);
    }
}