using Microsoft.EntityFrameworkCore;
using Wsei.Matches.Core.DbModel;

namespace Wsei.Matches.Infrastructure.Contexts
{
    public class MatchesDbContext : DbContext
    {
        public MatchesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Match>().HasOne(adv => adv.HomeTeam).WithMany(x => x.HomeMatches).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<Match>().HasOne(adv => adv.GuestTeam).WithMany(x => x.GuestMatches).OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Country>().HasData(new Country { Id = 1, Name = "TestCountry" });
            builder.Entity<Country>().HasData(new Country { Id = 2, Name = "TestCountry2" });
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
