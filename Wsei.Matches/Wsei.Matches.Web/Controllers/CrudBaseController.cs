using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;
public class CrudBaseController<T> : Controller
{
    private readonly IRepository<T> _repository;
    public CrudBaseController(IRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet("all")]
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<T> GetByIdAsync(int id)
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
    public async Task<bool> Add([FromBody] IEnumerable<T> countries)
    {
        await _repository.AddAsync(countries);
        return true;
    }

    [HttpPut("update")]
    public async Task<bool> Update([FromBody] IEnumerable<T> countries)
    {
        await _repository.UpdateAsync(countries);
        return true;
    }
}
