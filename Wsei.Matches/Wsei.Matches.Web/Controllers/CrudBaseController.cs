using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;
public class BaseCrudController<Request, Response> : Controller
{
    protected readonly IRepository<Request, Response> _repository;
    public BaseCrudController(IRepository<Request, Response> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Authorize(Roles = "User")]
    public virtual async Task<IEnumerable<Response>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public virtual async Task<Response> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id) ?? throw new Exception();
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public virtual async Task<bool> DeleteByIdAsync([FromBody] IEnumerable<int> id)
    {
        await _repository.DeleteAsync(id);
        return true;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public virtual async Task<bool> Add([FromBody] IEnumerable<Request> countries)
    {
        await _repository.AddAsync(countries);
        return true;
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public virtual async Task<bool> Update([FromBody] IEnumerable<Request> countries)
    {
        await _repository.UpdateAsync(countries);
        return true;
    }
}
