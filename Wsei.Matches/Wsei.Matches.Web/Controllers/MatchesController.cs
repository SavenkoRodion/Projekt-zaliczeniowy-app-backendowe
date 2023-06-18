using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/match")]
public class MatchesController : CrudBaseController<MatchDto>
{
    public MatchesController(IRepository<MatchDto> repository) : base(repository) { }
}


