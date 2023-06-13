using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Core.Interfaces.ServiceInterfaces;

namespace Wsei.Matches.Web.Controllers
{
    [ApiController]
    [Route("/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IRepository<CountryDto> _countryRepository;
        public CountryController(ICountryService countryService, IRepository<CountryDto> countryRepository)
        {
            _countryService = countryService;
            _countryRepository = countryRepository;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return await _countryRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<CountryDto> GetByCountryId(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id) ?? throw new Exception();
            return country;
        }
    }
}