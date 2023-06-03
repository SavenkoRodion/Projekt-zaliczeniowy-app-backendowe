using MathcesApi.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace MathcesApi
{
    public class MatchesDbContext : DbContext
    {
        public MatchesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Match>().HasOne(adv => adv.HomeTeam).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Match>().HasOne(adv => adv.GuestTeam).WithOne().OnDelete(DeleteBehavior.Restrict);
            /*              (adv => adv.PrimaryContact).WithOne().OnDelete(DeleteBehavior.Restrict);
                      builder.HasOne(adv => adv.AlternateContact).WithOne().OnDelete(DeleteBehavior.Restrict);*/
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
