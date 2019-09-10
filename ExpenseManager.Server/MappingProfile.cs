using ExpenseManager.Entities.Concrete;
using ExpenseManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Server
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountType, AccountTypeModel>();
            CreateMap<AccountTypeModel, AccountType>();

            CreateMap<Currency, CurrencyModel>();
            CreateMap<CurrencyModel, Currency>();

            CreateMap<Profile, ProfileModel>();
            CreateMap<ProfileModel, Profile>();
            CreateMap<UserSettings, UserSettingsModel>();
            CreateMap<UserSettingsModel, UserSettings>();
        }
    }
}
