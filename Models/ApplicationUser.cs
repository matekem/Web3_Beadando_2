using Microsoft.AspNetCore.Identity;

namespace Web3_Beadando.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
