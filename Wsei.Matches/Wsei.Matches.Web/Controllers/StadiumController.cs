using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/stadium")]
public class StadiumController : BaseCrudController<StadiumDto>
{
    public StadiumController(IRepository<StadiumDto> repository) : base(repository) { }
}


