using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieDb.Models;
using MovieDb.Models.Dao;

namespace MovieDb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<MovieDao> Movies { get; set; }
        public DbSet<ActorDao> Actors { get; set; }
        public DbSet<MovieReviewsDao> MovieReviews { get; set; }
        public DbSet<MovieMediaDao> MovieMedia { get; set; }
        public DbSet<UserFavoriteMoviesDao> FavoriteMoviesDaos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
        }


        private void SeedUsers(ModelBuilder builder)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "SuperAdmin",
                Email = "admin@imdbv2.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Cotur.123");

            builder.Entity<IdentityUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "SuperAdmin", ConcurrencyStamp = "1", NormalizedName = "SuperAdmin" },
                new IdentityRole() { Id = "g7b013f0-4101-4317-abd8-c211f91b7330", Name = "BasicUser", ConcurrencyStamp = "2", NormalizedName = "BasicUser" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Editor", ConcurrencyStamp = "3", NormalizedName = "Editor" }
                );
        }

    }
}