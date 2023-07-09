using Microsoft.EntityFrameworkCore;
using Wsei.TeamRatingsApi.Core.DbModel;

namespace Wsei.TeamRatingsApi.Infrastructure
{
    public class TeamRatingsDbContext : DbContext
    {
        public TeamRatingsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TeamRating> RatedTeams { get; set; }
    }
}
