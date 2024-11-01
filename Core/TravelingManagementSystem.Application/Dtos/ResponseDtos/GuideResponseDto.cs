using TravelingManagementSystem.Domain.Enums;

namespace TravelingManagementSystem.Application.Dtos.ResponseDtos;
public record GuideResponseDto(
    Guid Id,
    string Name,
    string Surname,
    DateTime DOB,
    string Email,
    string Phone,
    GuideType GuideType,
    ShiftType ShiftType);