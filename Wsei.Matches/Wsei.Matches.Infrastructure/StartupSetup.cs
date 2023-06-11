using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wsei.Matches.Application.Services;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Core.Interfaces.ServiceInterfaces;
using Wsei.Matches.Infrastructure.Contexts;

namespace Wsei.Matches.Infrastructure
{
    public class StartupSetup : IStartupSetup
    {
        public void AddDbContexts(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MatchesDbContext>(
                options => options.UseSqlServer(connectionString));
        }
        public void AddServicesToInterfaces(IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
        }
    }
}
