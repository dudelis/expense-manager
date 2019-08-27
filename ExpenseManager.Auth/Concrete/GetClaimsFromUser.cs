using ExpenseManager.Auth.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

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

        public GetClaimsFromUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
