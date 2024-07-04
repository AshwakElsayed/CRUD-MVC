using Microsoft.AspNetCore.Identity;

namespace MovieStore_MVC.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
