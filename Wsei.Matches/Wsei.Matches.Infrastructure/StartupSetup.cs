using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Wsei.Matches.Infrastructure.Dtos;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;
using Wsei.Matches.Infrastructure.Repositories;
using Wsei.Matches.Infrastructure.Services;

namespace Wsei.Matches.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContexts(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MatchesDbContext>(
                options => options.UseSqlServer(connectionString));
        }

        public static void AddRepositoriesToInterfaces(IServiceCollection services)
        {
            services.AddScoped<IRepository<CountryDto, CountryDto>, CountryRepository>();
            services.AddScoped<IRepository<MatchDtoRequest, MatchDtoResponse>, MatchRepository>();
            services.AddScoped<IRepository<TeamDtoRequest, TeamDtoResponse>, TeamRepository>();
            services.AddScoped<IRepository<StadiumDto, StadiumDto>, StadiumRepository>();
            services.AddScoped<IRepository<LeagueDtoRequest, LeagueDtoResponse>, LeagueRepository>();
        }

        public static void AddServicesToInterfaces(IServiceCollection services)
        {
            services.AddScoped<IMatchService, MatchService>();
        }

        public static void AddMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StartupSetup));
        }
    }
}
