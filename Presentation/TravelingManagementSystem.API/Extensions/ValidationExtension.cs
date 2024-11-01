using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TravelingManagementSystem.API.Extensions;

public static class ValidationExtension
{
    public static void AddToModalState(this ValidationResult result,ModelStateDictionary modelState)
    {
        foreach (var error in result.Errors)
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
    
}