using FluentValidation;
using TravelingManagementSystem.Application.Dtos.RequestDtos;

namespace TravelingManagementSystem.Infrastructure.Validation;

public class GroupValidator: AbstractValidator<GroupRequestDto>
{
    public GroupValidator()
    {
        RuleFor(g => g.MemberCount).NotEmpty().WithMessage("Member count cannot be empty")
            .InclusiveBetween((short)1,(short)100).WithMessage("Member count cannot be greater than 100");
        RuleFor(g => g.GuideId).NotNull().WithMessage("GuideId count cannot be null");
    }
}