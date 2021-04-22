using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, 
    IdentityUserClaim<int>,
     AppUserRole, IdentityUserLogin<int>,
     IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<REProperty> Properties{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
            .HasMany(_usr=>_usr.UserRoles)
            .WithOne(_u=>_u.User)
            .HasForeignKey(_fur=>_fur.UserId)
            .IsRequired();
            //for role
            builder.Entity<AppRole>()
            .HasMany(_usr=>_usr.UserRoles)
            .WithOne(_u=>_u.Role)
            .HasForeignKey(_fur=>_fur.RoleId)
            .IsRequired();
            //next step configure Startup class in IdentityServiceExtensions.cs
        }
    }
}