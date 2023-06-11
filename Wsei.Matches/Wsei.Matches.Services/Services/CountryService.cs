using Wsei.Matches.Core.ServiceInterfaces;

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
