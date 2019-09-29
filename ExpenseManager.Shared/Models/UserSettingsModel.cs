using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Shared.Models
{
    public class UserSettingsModel
    {
        [Required]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public Guid DefaultProfileId { get; set; }
    }
}
