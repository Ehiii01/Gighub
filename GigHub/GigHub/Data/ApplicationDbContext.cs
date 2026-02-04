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

     
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().HasKey(a => new { a.GigId, a.AttendeeId });
            modelBuilder.Entity<Following>().HasKey(f => new { f.FollowerId, f.FolloweeId });



            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithOne(f => f.Followee);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithOne(f => f.Follower);

            base.OnModelCreating(modelBuilder);
        }


    }
}
