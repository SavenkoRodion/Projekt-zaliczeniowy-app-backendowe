using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/league")]
public class LeagueController : BaseCrudController<MatchDtoRequest, MatchDtoResponse>
{
    public LeagueController(IRepository<MatchDtoRequest, MatchDtoResponse> repository) : base(repository) { }
}


