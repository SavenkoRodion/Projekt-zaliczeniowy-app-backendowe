using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/stadium")]
public class StadiumController : BaseCrudController<StadiumDto, StadiumDto>
{
    public StadiumController(IRepository<StadiumDto, StadiumDto> repository) : base(repository) { }
}


