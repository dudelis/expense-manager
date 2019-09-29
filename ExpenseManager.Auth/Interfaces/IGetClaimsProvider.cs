using System;

namespace ExpenseManager.Auth.Interfaces
{
    public interface IGetClaimsProvider
    {
        string UserId { get; }
        Guid UserProfileId { get; }
    }
}
