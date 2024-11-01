using FluentValidation;
using TravelingManagementSystem.Application.Dtos.RequestDtos;

namespace TravelingManagementSystem.Infrastructure.Validation;

public class GuideValidator:AbstractValidator<GuideRequestDto>
{
    public GuideValidator()
    {
        RuleFor(g => g.Name).NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters");
        RuleFor(g => g.Surname).NotEmpty().WithMessage("Surname cannot be empty")
            .MaximumLength(150).WithMessage("Surname must be less than 150 characters");
        RuleFor(g => g.Email).NotEmpty().WithMessage("Email cannot be empty").EmailAddress()
            .MaximumLength(250).WithMessage("Surname must be less than 250 characters");;
        RuleFor(g => g.Phone).NotEmpty().WithMessage("Phone cannot be empty")
            .Must(g => g.Contains("+994")).WithMessage("Phone must be starting +994");
        RuleFor(g => g.DOB).NotEmpty().WithMessage("DOB cannot be empty");
    }   
}