using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;

namespace TravelingManagementSystem.Application.Abstraction.Services;

public interface IGuideService
{
    Task<GuideResponseDto> CreateAsync(GuideRequestDto guideRequestDto);
    Task<GuideResponseDto> RemoveAsync(Guid id);
    Task<GuideResponseDto> GetAsync(Guid id);
    Task<IList<GuideResponseDto>> GetAllAsync();
    Task<GuideResponseDto> UpdateAsync(Guid id,GuideRequestDto requestDto);
}