using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/match")]
public class MatchController : BaseCrudController<MatchDto>
{
    public MatchController(IRepository<MatchDto> repository) : base(repository) { }
}


