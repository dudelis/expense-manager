using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;

namespace ExpenseManager.Business.Concrete
{
    public class UserSettingsManager : BaseManager<UserSettings, IUserSettingsRepository>, IUserSettingsService
    {
        public UserSettingsManager(IUserSettingsRepository repository) : base(repository)
        {
        }

    }
}
