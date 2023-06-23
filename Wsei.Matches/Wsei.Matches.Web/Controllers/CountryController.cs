using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/country")]
public class CountryController : BaseCrudController<CountryDto>
{
    public CountryController(IRepository<CountryDto> repository) : base(repository) { }
}