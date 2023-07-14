using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/country")]
public class CountryController : BaseCrudController<CountryDto, CountryDto>
{
    public CountryController(IRepository<CountryDto, CountryDto> repository) : base(repository) { }
}