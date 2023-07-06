using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/league")]
public class LeagueController : BaseCrudController<LeagueDto>
{
    public LeagueController(IRepository<LeagueDto> repository) : base(repository) { }
}


