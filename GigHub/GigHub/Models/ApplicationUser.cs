using Microsoft.AspNetCore.Identity;

namespace GigHub.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(string userName) : base(userName)
        {

        }

    }
}
