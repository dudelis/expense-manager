using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Interfaces
{
    public interface ICreationAudited: IHasCreationTime
    {
        string CreatorUserId { get; set; }
    }
}
