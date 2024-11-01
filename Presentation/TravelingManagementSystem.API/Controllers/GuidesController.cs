using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.API.Extensions;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using ILogger = Serilog.ILogger;

namespace TravelingManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuidesController(
    IGuideService _guideService,
    IValidator<GuideRequestDto> _validator,
    ILogger<GuidesController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Getting all guides");
        var response = await _guideService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        _logger.LogInformation("Getting a guide with {Id}",id);
        var response = await _guideService.GetAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(GuideRequestDto requestDto)
    {
        _logger.LogInformation("Creating a new guide");
        var result = await _validator.ValidateAsync(requestDto);
        if (result.IsValid)
        {
            var response = await _guideService.CreateAsync(requestDto);
            return Ok(response);
        }
        result.AddToModalState(ModelState);
        return Ok(requestDto);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id, GuideRequestDto requestDto)
    {
        _logger.LogInformation("Updating a guide with {Id}",id);
        var response = await _guideService.UpdateAsync(id, requestDto);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Deleting a guide with {Id}",id);
        var response = await _guideService.RemoveAsync(id);
        return Ok(response);
    }
}