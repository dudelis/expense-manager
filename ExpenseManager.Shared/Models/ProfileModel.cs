using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Shared.Models
{
    public class ProfileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfileOwner { get; set; }
    }
}
