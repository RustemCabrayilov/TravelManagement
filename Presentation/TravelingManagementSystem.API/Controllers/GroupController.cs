using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Infrastructure.Services.InternalServices;

namespace TravelingManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController(GroupService _groupService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response =await _groupService.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response =await _groupService.GetAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GroupRequestDto requestDto)
    {
        var response = await _groupService.CreateAsync(requestDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id,GroupRequestDto requestDto)
    {
        var response = await _groupService.UpdateAsync(id,requestDto);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _groupService.RemoveAsync(id);
        return Ok(response);
    }
}