using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public abstract class BaseEntity: IEntity, IAudited, IProfileDependent
    {
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }

        public int ProfileId { get; private set;}
        public Profile Profile { get; private set;}

        public void SetProfileId(int id)
        {
            ProfileId = id;
        }
    }

    public abstract class BaseEntity<TKey> : IEntity<TKey>, IAudited, IProfileDependent
    {
        public TKey Id { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }

        public int ProfileId { get; private set; }
        public Profile Profile { get; private set; }

        public void SetProfileId(int id)
        {
            ProfileId = id;
        }
    }
}
