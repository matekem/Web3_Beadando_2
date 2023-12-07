using Microsoft.AspNetCore.Identity;
using Web3_Beadando.Areas.Identity.Data;

namespace Web3_Beadando.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Role { get; set; }

    }
}
