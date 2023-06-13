using Microsoft.Extensions.DependencyInjection;

namespace Wsei.Matches.Core.Interfaces
{
    public interface IStartupSetup
    {
        public void AddDbContexts(IServiceCollection services, string connectionString);
        public void AddServicesToInterfaces(IServiceCollection services);
        public void AddRepositoriesToInterfaces(IServiceCollection services);
    }
}
