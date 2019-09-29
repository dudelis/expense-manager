using ExpenseManager.Entities.Interfaces;
using System;

namespace ExpenseManager.Entities.Concrete
{
    public abstract class BaseEntity : IEntity, IAudited
    {
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }
    }

    public abstract class BaseEntity<TKey> : IEntity<TKey>, IAudited
    {
        public TKey Id { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
