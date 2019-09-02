﻿using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Interfaces
{
    public interface IProfileMemberService: IServiceBase<ProfileMember, IProfileMemberRepository>
    {
        bool ItemExists(string userId);
    }
}
