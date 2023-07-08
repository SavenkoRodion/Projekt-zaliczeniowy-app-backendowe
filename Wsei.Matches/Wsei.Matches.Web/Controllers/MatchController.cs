using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos.Requests;
using Wsei.Matches.Application.Dtos.Responses;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/match")]
public class MatchController : BaseCrudController<MatchDtoRequest, MatchDtoResponse>
{
    public MatchController(IRepository<MatchDtoRequest, MatchDtoResponse> repository) : base(repository) { }
}


