using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Shared.Models
{
    public class UserInfoModel
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}
