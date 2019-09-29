//using ExpenseManager.Shared.Models;
using ExpenseManager.Shared.Models;
using System.Threading.Tasks;


namespace ExpenseManager.Client.Services.Interfaces
{
    public interface IAuthorizeApi
    {
        Task Login(LoginModel model);
        Task RefreshLogin();
        Task Register(RegisterModel model);
        Task Logout();
        Task<UserInfoModel> GetUserInfo();
    }
}
