using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Business.Interfaces
{
    public interface IUserSettingsService: IServiceBase<UserSettings, IUserSettingsRepository>
    {
    }
}
