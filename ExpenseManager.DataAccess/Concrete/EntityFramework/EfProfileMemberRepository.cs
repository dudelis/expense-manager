using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfProfileMemberRepository: EfEntityRepositoryBase<ProfileMember, ExpenseManagerDbContext>, IProfileMemberRepository
    {
        public EfProfileMemberRepository(ExpenseManagerDbContext context): base(context)
        {

        }
    }
}
