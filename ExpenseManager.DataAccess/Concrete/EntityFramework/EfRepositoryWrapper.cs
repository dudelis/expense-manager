﻿using ExpenseManager.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryWrapper : IRepositoryWrapper
    {
        private ExpenseManagerDbContext _context;
        private IAccountRepository _account;
        private IAccountTypeRepository _accountType;
        private ICurrencyRepository _currency;
        private IExpenseRepository _expense;
        private IExpenseCategoryRepository _expenseCategory;
        private IPayeeRepository _payee;

        public EfRepositoryWrapper(ExpenseManagerDbContext context)
        {
            _context = context;
        }
        public IAccountRepository Account {
            get
            {
                if (_account == null)
                {
                    _account = new EfAccountRepository(_context);
                }
                return _account;
            }
        }

        public IAccountTypeRepository AccountType
        {
            get
            {
                if (_accountType == null)
                {
                    _accountType = new EfAccountTypeRepository(_context);
                }
                return _accountType;
            }
        }

        public ICurrencyRepository Currency {
            get
            {
                if (_currency == null)
                {
                    _currency = new EfCurrencyRepository(_context);
                }
                return _currency;
            }
        }

        public IExpenseRepository Expense
        {
            get
            {
                if (_expense == null)
                {
                    _expense = new EfExpenseRepository(_context);
                }
                return _expense;
            }
        }

        public IExpenseCategoryRepository ExpenseCategory
        {
            get
            {
                if (_expenseCategory == null)
                {
                    _expenseCategory = new EfExpenseCategoryRepository(_context);
                }
                return _expenseCategory;
            }
        }

        public IPayeeRepository Payee
        {
            get
            {
                if (_payee == null)
                {
                    _payee = new EfPayeeRepository(_context);
                }
                return _payee;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
