using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Shared.Models
{
    public class AccountTypeModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

    }
}
