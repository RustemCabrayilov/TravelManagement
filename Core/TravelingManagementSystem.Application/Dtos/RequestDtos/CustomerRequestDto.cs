namespace TravelingManagementSystem.Application.Dtos.RequestDtos;

public record CustomerRequestDto(
    string Name,
    string Surname,
    string Nationality,
    bool IsHealty,
    string Email,
    string Phone,
    Guid GroupId);