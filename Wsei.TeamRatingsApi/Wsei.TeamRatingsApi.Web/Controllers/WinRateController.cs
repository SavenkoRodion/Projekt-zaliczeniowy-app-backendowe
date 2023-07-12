using Microsoft.AspNetCore.Mvc;
using Wsei.TeamRatingsApi.Core.Interfaces;
using Wsei.TeamRatingsApi.Infrastructure.Dtos;

namespace Wsei.TeamRatingsApi.Web.Controllers;

[ApiController]
[Route("/winRate")]
public class WinRateController : Controller
{
    protected readonly IRepository<TeamRatingDto, TeamRatingDto> _teamRatingRepository;
    public WinRateController(IRepository<TeamRatingDto, TeamRatingDto> repository)
    {
        _teamRatingRepository = repository;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<TeamRatingDto>> GetAllAsync()
    {
        return await _teamRatingRepository.GetAllAsync();
    }
}
