using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;

namespace TravelingManagementSystem.Application.Abstraction.Services;

public interface IGroupService
{
    Task<GroupResponseDto> CreateAsync(GroupRequestDto groupRequestDto);
    Task<GroupResponseDto> RemoveAsync(Guid id);
    Task<GroupResponseDto> GetAsync(Guid id);
    Task<IList<GroupResponseDto>> GetAllAsync();
    Task<GroupResponseDto> UpdateAsync(Guid id,GroupRequestDto requestDto);
}