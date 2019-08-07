using AutoMapper;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            //Entities -> ViewModels
            CreateMap<AccountType, AccountTypeViewModel>();
            CreateMap<Account, AccountViewModel>();
            CreateMap<AccountType, AccountTypeViewModel>();
            CreateMap<AccountType, AccountTypeViewModel>();
            CreateMap<AccountType, AccountTypeViewModel>();
            CreateMap<AccountType, AccountTypeViewModel>();



            //ViewModels -> Entities
            CreateMap<AccountTypeViewModel, AccountType>();
        }
    }
}
