﻿using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Entities.Concrete
{
    public class UserSettings: IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Guid DefaultProfileId { get; set; }
        public Profile DefaultProfile { get; set; }
    }
}