using FluentValidation;
using TravelingManagementSystem.Application.Dtos.RequestDtos;
using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Infrastructure.Validation;

public class CustomerValidator:AbstractValidator<CustomerRequestDto>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name cannot be empty")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters");
        RuleFor(c => c.Surname).NotEmpty().WithMessage("Surname cannot be empty")
            .MaximumLength(150).WithMessage("Surname must be less than 150 characters");
        RuleFor(c => c.Email).NotEmpty().WithMessage("Email cannot be empty").EmailAddress()
            .MaximumLength(250).WithMessage("Surname must be less than 250 characters");;
        RuleFor(c => c.Phone).NotEmpty().WithMessage("Phone cannot be empty")
            .Must(c => c.Contains("+994")).WithMessage("Phone must be starting +994");
    }
}