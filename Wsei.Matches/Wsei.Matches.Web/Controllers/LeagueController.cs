﻿using Microsoft.AspNetCore.Mvc;
using Wsei.Matches.Application.Dtos.Requests;
using Wsei.Matches.Application.Dtos.Responses;
using Wsei.Matches.Core.Interfaces;

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
    public virtual async Task<bool> Update([FromBody] IEnumerable<LeagueDtoRequest> countries)
    {
        await _repository.UpdateAsync(countries);
        return true;
    }
}


