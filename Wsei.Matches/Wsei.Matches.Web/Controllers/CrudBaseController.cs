﻿using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Core.Interfaces;

namespace Wsei.Matches.Web.Controllers;
public class BaseCrudController<T> : Controller
{
    protected readonly IRepository<T> _repository;
    public BaseCrudController(IRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet("all")]
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public virtual async Task<T> GetByIdAsync(int id)
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
    public virtual async Task<bool> Add([FromBody] IEnumerable<T> countries)
    {
        await _repository.AddAsync(countries);
        return true;
    }

    [HttpPut("update")]
    public virtual async Task<bool> Update([FromBody] IEnumerable<T> countries)
    {
        await _repository.UpdateAsync(countries);
        return true;
    }
}