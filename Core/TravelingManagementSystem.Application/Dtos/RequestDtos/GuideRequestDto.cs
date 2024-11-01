using TravelingManagementSystem.Domain.Enums;

namespace TravelingManagementSystem.Application.Dtos.RequestDtos;
public record GuideRequestDto(
    string Name,
    string Surname,
    DateTime DOB,
    string Email,
    string Phone,
    GuideType GuideType,
    ShiftType ShiftType);