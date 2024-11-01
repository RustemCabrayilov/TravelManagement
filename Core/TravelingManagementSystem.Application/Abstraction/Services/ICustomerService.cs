using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;

namespace TravelingManagementSystem.Application.Abstraction.Services;

public interface ICustomerService
{
    Task<CustomerResponseDto> CreateAsync(CustomerRequestDto customerRequestDto);
    Task<CustomerResponseDto> RemoveAsync(Guid id);
    Task<CustomerResponseDto> GetAsync(Guid id);
   Task<IList<CustomerResponseDto>> GetAllAsync();
    Task<CustomerResponseDto> UpdateAsync(Guid id,CustomerRequestDto requestDto);
}