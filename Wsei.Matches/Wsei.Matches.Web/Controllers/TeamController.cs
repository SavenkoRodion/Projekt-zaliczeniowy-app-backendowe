using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/team")]
public class TeamController : BaseCrudController<TeamDtoRequest, TeamDtoResponse>
{
    public TeamController(IRepository<TeamDtoRequest, TeamDtoResponse> repository) : base(repository) { }
}


