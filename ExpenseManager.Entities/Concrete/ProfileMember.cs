using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class ProfileMember: IEntity<int>
    {
        public int Id { get; set; }        
        public string UserId { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }        
    }
}
