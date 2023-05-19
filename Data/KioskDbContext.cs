using KGKioskWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KGKioskWebAPI.Data
{
    public class KioskDbContext : DbContext
    {
        public KioskDbContext(DbContextOptions<KioskDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<UserWithRoles> UserWithRoles { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure any additional model mappings or relationships here

        //    // Example: Configure many-to-many relationship between User and Role
        //    modelBuilder.Entity<UserRole>()
        //        .HasKey(ur => new { ur.UserId, ur.RoleId });

        //    modelBuilder.Entity<UserRole>()
        //        .HasOne(ur => ur.User)
        //        .WithMany(u => u.UserRoles)
        //        .HasForeignKey(ur => ur.UserId);
        //}
    }
}
