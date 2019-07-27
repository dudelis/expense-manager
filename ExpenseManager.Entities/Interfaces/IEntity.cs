using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
    }
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
    
}
