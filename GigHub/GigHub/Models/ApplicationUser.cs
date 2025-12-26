using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public ApplicationUser()
        {

        }

        public ApplicationUser(string userName) : base(userName)
        {

        }

    }
}
