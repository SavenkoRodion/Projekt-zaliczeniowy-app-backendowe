using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/team")]
public class TeamController : BaseCrudController<TeamDto>
{
    public TeamController(IRepository<TeamDto> repository) : base(repository) { }
}


