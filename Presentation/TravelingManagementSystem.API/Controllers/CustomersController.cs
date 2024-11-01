using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Application.Dtos.RequestDtos;

namespace TravelingManagementSystem.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService _customerService) : ControllerBase
{
    
    [HttpGet]
    public async  Task<IActionResult> GetAll()
    {
        var response = await _customerService.GetAllAsync();
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response =await _customerService.GetAsync(id);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Post(CustomerRequestDto requestDto)
    {
        var response = await _customerService.CreateAsync(requestDto);
        return Ok(response);    
    }

    [HttpPut]
    public async Task<IActionResult> Put(Guid id,CustomerRequestDto requestDto)
    {
        var response = await _customerService.UpdateAsync(id,requestDto);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _customerService.RemoveAsync(id);
        return Ok(response);
    }
}