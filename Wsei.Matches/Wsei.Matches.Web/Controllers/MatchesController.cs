using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Core.Interfaces.ServiceInterfaces;

namespace Wsei.Matches.Web.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ICountryService _matchService;
        private readonly IRepository<MatchDto> _matchRepository;
        public MatchesController(ICountryService countryService, IRepository<MatchDto> countryRepository)
        {
            _matchService = countryService;
            _matchRepository = countryRepository;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<MatchDto>> GetAllAsync()
        {
            return await _matchRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<MatchDto> GetCountryByIdAsync(int id)
        {
            return await _matchRepository.GetByIdAsync(id) ?? throw new Exception();
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteCountryByIdAsync([FromBody] IEnumerable<int> id)
        {
            await _matchRepository.DeleteAsync(id);
            return true;
        }

        [HttpPost("add")]
        public async Task<bool> Add([FromBody] IEnumerable<MatchDto> countries)
        {
            await _matchRepository.AddAsync(countries);
            return true;
        }

        [HttpPut("update")]
        public async Task<bool> Update([FromBody] IEnumerable<MatchDto> countries)
        {
            await _matchRepository.UpdateAsync(countries);
            return true;
        }
    }
}
