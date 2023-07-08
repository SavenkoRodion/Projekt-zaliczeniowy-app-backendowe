using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/stadium")]
public class StadiumController : BaseCrudController<StadiumDto, StadiumDto>
{
    public StadiumController(IRepository<StadiumDto, StadiumDto> repository) : base(repository) { }
}


