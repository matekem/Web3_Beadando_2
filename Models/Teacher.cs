using Microsoft.AspNetCore.Identity;

namespace Web3_Beadando.Models
{
    public class Teacher : IdentityUser<string>
    {
         public string FullName { get; set; }
    }
}
