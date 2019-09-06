﻿using ExpenseManager.Entities.Concrete;
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
            CreateMap<Currency, CurrencyModel>();
            CreateMap<CurrencyModel, Currency>();
        }
    }
}
