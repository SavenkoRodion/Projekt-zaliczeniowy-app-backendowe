using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos.Requests;
using Wsei.Matches.Application.Dtos.Responses;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/team")]
public class TeamController : BaseCrudController<TeamDtoRequest, TeamDtoResponse>
{
    public TeamController(IRepository<TeamDtoRequest, TeamDtoResponse> repository) : base(repository) { }
}


