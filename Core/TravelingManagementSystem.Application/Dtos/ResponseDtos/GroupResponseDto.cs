using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Application.Dtos.ResponseDtos;

public record GroupResponseDto(
    Guid Id,
    short MemberCount,
    GuideResponseDto Guide,
    ICollection<CustomerResponseDto> Customers);