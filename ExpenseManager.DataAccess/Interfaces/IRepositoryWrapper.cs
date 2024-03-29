﻿using System.Threading.Tasks;

namespace ExpenseManager.DataAccess.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        IAccountTypeRepository AccountType { get; }
        ICurrencyRepository Currency { get; }
        IExpenseRepository Expense { get; }
        IExpenseCategoryRepository ExpenseCategory { get; }
        IPayeeRepository Payee { get; }
        IProfileRepository Profile { get; }
        IProfileMemberRepository ProfileMember { get; }
        void Save();
        Task SaveAsync();
    }
}
