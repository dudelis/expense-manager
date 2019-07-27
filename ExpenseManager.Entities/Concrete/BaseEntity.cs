using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public abstract class BaseEntity<TPrimaryKeyDataType>: IEntity<TPrimaryKeyDataType>, IAudited
    {
        public TPrimaryKeyDataType Id { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
