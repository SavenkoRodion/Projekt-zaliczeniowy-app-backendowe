using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wsei.TeamRatingsApi.Core.Interfaces;
using Wsei.TeamRatingsApi.Infrastructure.Dtos;
using Wsei.TeamRatingsApi.Infrastructure.Repositories;

namespace Wsei.TeamRatingsApi.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContexts(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TeamRatingsDbContext>(
                options => options.UseSqlServer(connectionString));
        }
        public static void AddRepositoriesToInterfaces(IServiceCollection services)
        {
            services.AddScoped<ITeamRatingRepository<TeamRatingDto, TeamRatingDto>, TeamRatingsRepository>();
        }
    }
}
