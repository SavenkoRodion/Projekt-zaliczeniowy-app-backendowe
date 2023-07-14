using Microsoft.AspNetCore.Mvc;
using Wsei.TeamRatingsApi.Core.Interfaces;
using Wsei.TeamRatingsApi.Infrastructure.Dtos;

namespace Wsei.TeamRatingsApi.Web.Controllers;

[ApiController]
[Route("/teamRating")]
public class TeamRatingController : Controller
{
    protected readonly ITeamRatingRepository<TeamRatingDto, TeamRatingDto> _teamRatingRepository;
    public TeamRatingController(ITeamRatingRepository<TeamRatingDto, TeamRatingDto> repository)
    {
        _teamRatingRepository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<TeamRatingDto>> GetAllAsync()
    {
        return await _teamRatingRepository.GetAllAsync();
    }

    [HttpGet("byId/{id}")]
    public async Task<TeamRatingDto?> GetByIdAsync(int id)
    {
        return await _teamRatingRepository.GetByIdAsync(id);
    }

    [HttpGet("byTeamName/{teamName}")]
    public async Task<TeamRatingDto?> GetByTeamNameAsync(string teamName)
    {
        return await _teamRatingRepository.GetByNameAsync(teamName);
    }

    [HttpDelete]
    public async Task<bool> DeleteByIdAsync([FromBody] IEnumerable<int> id)
    {
        await _teamRatingRepository.DeleteAsync(id);
        return true;
    }

    [HttpPost]
    public async Task<bool> Add([FromBody] IEnumerable<TeamRatingDto> countries)
    {
        await _teamRatingRepository.AddAsync(countries);
        return true;
    }

    [HttpPut]
    public async Task<bool> Replace([FromBody] IEnumerable<TeamRatingDto> countries)
    {
        await _teamRatingRepository.ReplaceAsync(countries);
        return true;
    }
}
