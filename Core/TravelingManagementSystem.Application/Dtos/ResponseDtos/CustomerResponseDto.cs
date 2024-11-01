namespace TravelingManagementSystem.Application.Dtos.ResponseDtos;


public record CustomerResponseDto(Guid Id,string Name,string Surname, string Nationality,bool IsHealty,string Email, string Phone);