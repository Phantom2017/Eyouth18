using Microsoft.AspNetCore.Identity;

namespace Eyouth1.Models
{
    public class AppUser:IdentityUser
    {
        public string Address { get; set; }

        public Employee Employee { get; set; }
    }
}
