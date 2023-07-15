using Microsoft.EntityFrameworkCore;
using Wsei.AutorizationApi.Models;

namespace Wsei.AutorizationApi.Controllers
{
    public class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
