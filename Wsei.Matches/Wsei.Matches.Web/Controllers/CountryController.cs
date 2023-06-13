using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.DbModel;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Core.Interfaces.ServiceInterfaces;

namespace Wsei.Matches.Web.Controllers
{
    [ApiController]
    [Route("/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IRepository<Country> _countryRepository;
        public CountryController(ICountryService countryService, IRepository<Country> countryRepository)
        {
            _countryService = countryService;
            _countryRepository = countryRepository;
        }

        [HttpGet("all")]
        public IEnumerable<Country> All()
        {
            return _countryRepository.GetAll();
        }
    }
}