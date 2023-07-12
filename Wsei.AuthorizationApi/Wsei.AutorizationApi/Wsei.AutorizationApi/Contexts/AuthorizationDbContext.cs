using Microsoft.EntityFrameworkCore;

namespace Wsei.AutorizationApi.Controllers
{
    public class AuthorizationDbContext : DbContext
    {
        public AuthorizationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<UserDto> Users { get; set; }

    }
}
