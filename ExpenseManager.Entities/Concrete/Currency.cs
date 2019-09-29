using ExpenseManager.Entities.Interfaces;
using System;

namespace ExpenseManager.Entities.Concrete
{
    public class Currency : BaseEntity, IProfileDependent
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public Guid ProfileId { get; private set; }
        public Profile Profile { get; set; }

        public void SetProfileId(Guid profileGuid)
        {
            ProfileId = profileGuid;
        }
    }
}
