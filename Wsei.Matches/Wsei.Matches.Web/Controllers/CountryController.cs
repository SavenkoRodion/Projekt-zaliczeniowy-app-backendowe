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
        public async Task<CountryDto> GetCountryByIdAsync(int id)
        {
            return await _countryRepository.GetByIdAsync(id) ?? throw new Exception();
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteCountryByIdAsync([FromBody] IEnumerable<int> id)
        {
            await _countryRepository.DeleteAsync(id);
            return true;
        }

        [HttpPost("add")]
        public async Task<bool> Add([FromBody] IEnumerable<CountryDto> countries)
        {
            await _countryRepository.AddAsync(countries);
            return true;
        }

        [HttpPut("update")]
        public async Task<bool> Update([FromBody] IEnumerable<CountryDto> countries)
        {
            await _countryRepository.UpdateAsync(countries);
            return true;
        }
    }
}