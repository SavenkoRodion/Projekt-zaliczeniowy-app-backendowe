using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/league")]
public class LeagueController : Controller
{
    protected readonly IRepository<LeagueDtoRequest, LeagueDtoResponse> _repository;
    public LeagueController(IRepository<LeagueDtoRequest, LeagueDtoResponse> repository)
    {
        _repository = repository;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<LeagueDtoResponse>> GetAllAsync()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7206");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.GetAsync("/teamRating/all");
        var lol = await response.Content.ReadAsStringAsync();
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<LeagueDtoResponse> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id) ?? throw new Exception();
    }

    [HttpDelete("delete")]
    public async Task<bool> DeleteByIdAsync([FromBody] IEnumerable<int> id)
    {
        await _repository.DeleteAsync(id);
        return true;
    }

    [HttpPost("add")]
    public async Task<bool> Add([FromBody] IEnumerable<LeagueDtoRequest> countries)
    {
        await _repository.AddAsync(countries);
        return true;
    }

    [HttpPut("update")]
    public async Task<bool> Update([FromBody] IEnumerable<LeagueDtoRequest> countries)
    {
        await _repository.UpdateAsync(countries);
        return true;
    }
}


