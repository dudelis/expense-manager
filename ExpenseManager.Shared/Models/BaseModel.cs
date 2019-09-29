using System;

namespace ExpenseManager.Shared.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
