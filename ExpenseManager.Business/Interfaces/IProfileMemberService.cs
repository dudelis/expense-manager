using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Interfaces
{
    public interface IProfileMemberService : IServiceBase<ProfileMember, IProfileMemberRepository>
    {
        bool ItemExists(string userId);
    }
}
