using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfProfileMemberRepository : EfEntityRepositoryBase<ProfileMember, int, ExpenseManagerDbContext>, IProfileMemberRepository
    {
        public EfProfileMemberRepository(ExpenseManagerDbContext context) : base(context)
        {

        }
    }
}
