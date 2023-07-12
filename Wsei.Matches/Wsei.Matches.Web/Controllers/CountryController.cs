using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/country")]
public class CountryController : BaseCrudController<CountryDto, CountryDto>
{
    public CountryController(IRepository<CountryDto, CountryDto> repository) : base(repository) { }
}