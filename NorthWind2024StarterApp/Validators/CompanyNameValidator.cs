using FluentValidation;
using NorthWind2024StarterApp.Models;

namespace NorthWind2024StarterApp.Validators;

public class CompanyNameValidator : AbstractValidator<CustomerItem>
{
    public CompanyNameValidator()
    {
        RuleFor(CustomerItem => CustomerItem.CompanyName)
            .NotEmpty()
            .MinimumLength(3);
    }
}