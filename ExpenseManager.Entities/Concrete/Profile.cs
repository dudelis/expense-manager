using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpenseManager.Entities.Concrete
{
    public class Profile : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProfileOwner { get; set; }

        public ProfileConfiguration ProfileConfiguration { get; set; }
        public ICollection<ProfileMember> ProfileMembers { get; set; }
        public ICollection<UserSettings> UserSettings { get; set; }

    }
}
