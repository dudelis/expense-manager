using ExpenseManager.Entities.Concrete;
using ExpenseManager.Shared.Models;

namespace ExpenseManager.Server
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountType, AccountTypeModel>();
            CreateMap<AccountTypeModel, AccountType>();

            CreateMap<Currency, CurrencyModel>();
            CreateMap<CurrencyModel, Currency>();
            CreateMap<ExpenseCategoryModel, ExpenseCategory>();
            CreateMap<ExpenseCategory, ExpenseCategoryModel>();

            CreateMap<Payee, PayeeModel>();
            CreateMap<PayeeModel, Payee>();
            CreateMap<Profile, ProfileModel>();
            CreateMap<ProfileModel, Profile>();
            CreateMap<UserSettings, UserSettingsModel>();
            CreateMap<UserSettingsModel, UserSettings>();
        }
    }
}
