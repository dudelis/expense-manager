using System;

namespace ExpenseManager.Web.Core.Models
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
