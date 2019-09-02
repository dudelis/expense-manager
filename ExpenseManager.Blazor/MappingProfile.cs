using ExpenseManager.Entities.Concrete;
using ExpenseManager.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Blazor
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<CurrencyViewModel, Currency>();
        }
    }
}
