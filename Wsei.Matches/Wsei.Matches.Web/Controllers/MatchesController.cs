using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/matches")]
public class MatchesController : BaseCrudController<MatchDto>
{
    public MatchesController(IRepository<MatchDto> repository) : base(repository) { }
}


