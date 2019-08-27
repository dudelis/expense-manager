using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseManager.Web.Core.Models
{
    public class Profile
    {
        public int Guid { get; set; }
        [Required]
        public string Name { get; set; }
        public string ProfileOwner { get; set; }

        public ProfileConfiguration ProfileConfiguration { get; set; }
        public ICollection<ProfileMember> ProfileMembers { get; set; }
    }
}
