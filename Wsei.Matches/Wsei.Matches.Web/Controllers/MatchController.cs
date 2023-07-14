using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;
using Wsei.Matches.Infrastructure.Dtos.Requests;
using Wsei.Matches.Infrastructure.Dtos.Responses;

namespace Wsei.Matches.Web.Controllers;

[ApiController]
[Route("/match")]
public class MatchController
{
    protected readonly IRepository<MatchDtoRequest, MatchDtoResponse> _repository;
    public MatchController(IRepository<MatchDtoRequest, MatchDtoResponse> repository)
    {
        _repository = repository;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<MatchDtoResponse>> GetAllAsync()
    {
        var allMatches = await _repository.GetAllAsync();
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public virtual async Task<MatchDtoResponse> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id) ?? throw new Exception();
    }

    [HttpDelete("delete")]
    public virtual async Task<bool> DeleteByIdAsync([FromBody] IEnumerable<int> id)
    {
        await _repository.DeleteAsync(id);
        return true;
    }

    [HttpPost("add")]
    public virtual async Task<bool> Add([FromBody] IEnumerable<MatchDtoRequest> countries)
    {
        await _repository.AddAsync(countries);
        return true;
    }

    [HttpPut("update")]
    public virtual async Task<bool> Update([FromBody] IEnumerable<MatchDtoRequest> countries)
    {
        await _repository.UpdateAsync(countries);
        return true;
    }
}


