using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Business.Concrete
{
    public class UserSettingsManager: BaseManager<UserSettings, IUserSettingsRepository>, IUserSettingsService
    {
        public UserSettingsManager(IUserSettingsRepository repository): base(repository)
        {
        }

    }
}
