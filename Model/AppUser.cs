using Microsoft.AspNetCore.Identity;

namespace Estore.Model
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
