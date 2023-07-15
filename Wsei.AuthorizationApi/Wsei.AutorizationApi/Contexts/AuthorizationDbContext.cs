using Microsoft.EntityFrameworkCore;
using Wsei.AutorizationApi.Models;

namespace Wsei.AutorizationApi.Contexts
{
    public class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            PasswordUtil.CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
            builder
                .Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsAdmin = true
                });
        }

        public DbSet<User> Users { get; set; }
    }
}
