using Microsoft.AspNetCore.Mvc;
using Wsei.TeamRatingsApi.Core.Interfaces;
using Wsei.TeamRatingsApi.Infrastructure.Dtos;

namespace Wsei.TeamRatingsApi.Web.Controllers;

[ApiController]
[Route("/teamRating")]
public class TeamRatingController : Controller
{
    protected readonly IRepository<TeamRatingDto, TeamRatingDto> _teamRatingRepository;
    public TeamRatingController(IRepository<TeamRatingDto, TeamRatingDto> repository)
    {
        _teamRatingRepository = repository;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<TeamRatingDto>> GetAllAsync()
    {
        return await _teamRatingRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<TeamRatingDto> GetByIdAsync(int id)
    {
        return await _teamRatingRepository.GetByIdAsync(id) ?? throw new Exception();
    }

    [HttpDelete("delete")]
    public async Task<bool> DeleteByIdAsync([FromBody] IEnumerable<int> id)
    {
        await _teamRatingRepository.DeleteAsync(id);
        return true;
    }

    [HttpPost("add")]
    public async Task<bool> Add([FromBody] IEnumerable<TeamRatingDto> countries)
    {
        await _teamRatingRepository.AddAsync(countries);
        return true;
    }

    [HttpPut("replace")]
    public async Task<bool> Replace([FromBody] IEnumerable<TeamRatingDto> countries)
    {
        await _teamRatingRepository.ReplaceAsync(countries);
        return true;
    }
}
