using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Shared.Models
{
    public class CurrencyModel : BaseModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "Code should not contain more than 3 characters")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Symbol { get; set; }

    }
}
