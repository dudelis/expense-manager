using ExpenseManager.Auth.Interfaces;
using ExpenseManager.Shared.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace ExpenseManager.Auth.Concrete
{
    public class GetClaimsFromUser : IGetClaimsProvider
    {
        private IHttpContextAccessor _accessor;

        public string UserId
        {
            get
            {
                return _accessor.HttpContext?.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            }
        }
        public Guid UserProfileId
        {
            get
            {
                var guid = Guid.Parse(_accessor.HttpContext?.User.Claims.SingleOrDefault(x => x.Type == CustomClaimTypes.DefaultProfileGuid)?.Value);
                return guid;
            }
        }

        public GetClaimsFromUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
