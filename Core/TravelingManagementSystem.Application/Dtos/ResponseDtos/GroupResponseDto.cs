using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Application.Dtos.ResponseDtos;

public record GroupResponseDto(
    Guid Id,
    short MemberCount,
    Guide Guide,
    ICollection<Customer> Customers);