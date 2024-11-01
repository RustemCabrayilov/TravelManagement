using AutoMapper;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Application.Dtos.ResponseDtos;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Infrastructure.Mapping;

public class CustomProfile:Profile
{
    public CustomProfile()
    {
        CreateMap<CustomerRequestDto, CustomerResponseDto>().ReverseMap();
        CreateMap<CustomerRequestDto, Customer>().ReverseMap();
        CreateMap<CustomerResponseDto, Customer>().ReverseMap();
        CreateMap<GuideRequestDto, GuideResponseDto>().ReverseMap();
        CreateMap<GuideRequestDto, Guide>().ReverseMap();
        CreateMap<GuideResponseDto, Guide>().ReverseMap();
    }
}