using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Application.Dtos.Requests;
using Wsei.Matches.Application.Dtos.Responses;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Contexts;
using Wsei.Matches.Infrastructure.Repositories;

namespace Wsei.Matches.Infrastructure
{
    public class StartupSetup : IStartupSetup
    {
        public void AddDbContexts(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MatchesDbContext>(
                options => options.UseSqlServer(connectionString));
        }

        public void AddRepositoriesToInterfaces(IServiceCollection services)
        {
            services.AddScoped<IRepository<CountryDto, CountryDto>, CountryRepository>();
            services.AddScoped<IRepository<MatchDtoRequest, MatchDtoResponse>, MatchRepository>();
            services.AddScoped<IRepository<TeamDtoRequest, TeamDtoResponse>, TeamRepository>();
            services.AddScoped<IRepository<StadiumDto, StadiumDto>, StadiumRepository>();
            services.AddScoped<IRepository<LeagueDtoRequest, LeagueDtoResponse>, LeagueRepository>();
        }

        public void AddMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StartupSetup));
        }
    }
}
