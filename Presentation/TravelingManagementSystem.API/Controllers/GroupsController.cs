using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.API.Extensions;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using ILogger = Serilog.ILogger;

namespace TravelingManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController(IGroupService _groupService,
    IValidator<GroupRequestDto> _validator,
   ILogger<GroupsController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Getting all groups");
        var response = await _groupService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        _logger.LogInformation("Getting group with id: {id}", id);
        var response = await _groupService.GetAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GroupRequestDto requestDto)
    {
        var result = await _validator.ValidateAsync(requestDto);
        _logger.LogInformation("Creating new group");
        if (result.IsValid)
        {
            var response = await _groupService.CreateAsync(requestDto);
            return Ok(response);
        }
        result.AddToModalState(ModelState);
        return Ok(requestDto);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id, GroupRequestDto requestDto)
    {
        _logger.LogInformation("Updating group with id: {id}", id);
        var response = await _groupService.UpdateAsync(id, requestDto);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Deleting group with id: {id}", id);
        var response = await _groupService.RemoveAsync(id);
        return Ok(response);
    }
}