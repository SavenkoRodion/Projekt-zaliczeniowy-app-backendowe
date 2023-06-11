using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.ServiceInterfaces;

namespace Wsei.Matches.Web.Controllers
{
    [ApiController]
    [Route("/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("all")]
        public string All()
        {
            return _countryService.Test();
        }
    }
}