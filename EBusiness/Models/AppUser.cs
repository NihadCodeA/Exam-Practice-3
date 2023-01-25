using Microsoft.AspNetCore.Identity;

namespace EBusiness.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsAdmin { get; set; }
    }
}
