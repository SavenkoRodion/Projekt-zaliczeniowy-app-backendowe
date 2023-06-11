using Wsei.Matches.Core.Interfaces.ServiceInterfaces;

namespace Wsei.Matches.Application.Services
{
    public class CountryService : ICountryService
    {
        public CountryService() { }

        public string Test()
        {
            return "Test message";
        }
    }

}
