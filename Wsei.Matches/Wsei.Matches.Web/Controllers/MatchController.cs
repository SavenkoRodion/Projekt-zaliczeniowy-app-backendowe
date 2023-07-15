using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/match")]
public class MatchController : BaseCrudController<MatchDtoRequest, MatchDtoResponse>
{
    public MatchController(IRepository<MatchDtoRequest, MatchDtoResponse> repository) : base(repository) { }
}


