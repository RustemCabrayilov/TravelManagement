using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.API.Extensions;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
namespace TravelingManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(
    ICustomerService _customerService,
    IValidator<CustomerRequestDto> _validator,
    ILogger<CustomersController> _logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Getting all Customers");
        var response = await _customerService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        /*LogContext.PushProperty("Id", id);*/
        _logger.LogInformation("Getting Customer with Id: {Id}", id);
        var response = await _customerService.GetAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CustomerRequestDto requestDto)
    {
        _logger.LogInformation("Creating new customer");
        var result = await _validator.ValidateAsync(requestDto);
        if (result.IsValid)
        {
            var response = await _customerService.CreateAsync(requestDto);
            return Ok(response);
        }

        result.AddToModalState(ModelState);
        return Ok(requestDto);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id, CustomerRequestDto requestDto)
    {
        _logger.LogInformation("Updating customer with {Id}", id);
        var response = await _customerService.UpdateAsync(id, requestDto);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        _logger.LogInformation("Delete Customer with Id: {Id}", id);
        var response = await _customerService.RemoveAsync(id);
        return Ok(response);
    }
}