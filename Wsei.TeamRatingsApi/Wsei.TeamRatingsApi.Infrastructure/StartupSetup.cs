using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Wsei.TeamRatingsApi.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContexts(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TeamRatingsDbContext>(
                options => options.UseSqlServer(connectionString));
        }
    }
}
