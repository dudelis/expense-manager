
using Microsoft.AspNetCore.Identity;

namespace ExpenseManager.Auth.Concrete
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
