using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Domain.Entities;

namespace WebApplication.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<District> Districts { get; set; } = null!;
        public DbSet<ShawarmaPlace> ShawarmaPlaces { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin";
            string roleAdminId = "DA36513F-6393-43B8-A1E1-5CDF3D8EB6BF";
            string userAdminId = "FA2325ED-7786-447A-BA83-93C89FE17D93";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), adminName),
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });

            builder.Entity<District>().HasData(
                new District { Id = 1, Title = "Ленинский район", DateCreated = new DateTime(2024, 1, 1) },
                new District { Id = 2, Title = "Октябрьский район", DateCreated = new DateTime(2024, 1, 1) },
                new District { Id = 3, Title = "Первомайский район", DateCreated = new DateTime(2024, 1, 1) },
                new District { Id = 4, Title = "Индустриальный район", DateCreated = new DateTime(2024, 1, 1) },
                new District { Id = 5, Title = "Устиновский район", DateCreated = new DateTime(2024, 1, 1) }
            );
        }
    }
}