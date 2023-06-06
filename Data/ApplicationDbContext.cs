using Bortsevych.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Bortsevych.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Project> Projects { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Id = "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            builder.Entity<IdentityUser>().HasData(new IdentityUser
                {      
                    Id = "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4",
                    UserName = "administrator@gmail.com",
                    NormalizedUserName = "ADMINISTRATOR@GMAIL.COM",
                    Email = "administrator@gmail.com",
                    NormalizedEmail = "ADMINISTRATOR@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Administrator"),
                    SecurityStamp = string.Empty
                });

#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf",
                UserId = "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4"
            });

        }

    }
}