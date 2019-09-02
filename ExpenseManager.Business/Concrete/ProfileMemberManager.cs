using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Concrete
{
    public class ProfileMemberManager : BaseManager<ProfileMember, int, IProfileMemberRepository>, IProfileMemberService
    {

        public ProfileMemberManager(IProfileMemberRepository repository): base(repository)
        {
        }

        public bool ItemExists(string userId)
        {
            return this.Repository.ItemExists(x => x.UserId == userId);
        }
    }
}
