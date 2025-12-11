using GigHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GigHub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        //public ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
