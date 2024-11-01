using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Dtos.RequestDtos;

namespace TravelingManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuidesController(IGuideService _guideService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response =await _guideService.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response =await _guideService.GetAsync(id);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Post(GuideRequestDto requestDto)
    {
        var response =await _guideService.CreateAsync(requestDto);
        return Ok(response);
    }
    [HttpPut]
    public async Task<IActionResult> Put(Guid id,GuideRequestDto requestDto)
    {
        var response =await _guideService.UpdateAsync(id, requestDto);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response =await _guideService.RemoveAsync(id);
        return Ok(response);
    }
}