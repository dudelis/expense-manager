using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Auth.Interfaces
{
    public interface IGetClaimsProvider
    {
        string UserId { get; }
        Guid UserProfileId { get; }
    }
}
