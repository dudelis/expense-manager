using System.ComponentModel.DataAnnotations;

namespace ExpenseManager.Web.Core.Models
{
    public class CurrencyViewModel : BaseViewModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "Code should not contain more than 3 characters")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Symbol { get; set; }

        public bool Selected { get; set; }
    }
}
