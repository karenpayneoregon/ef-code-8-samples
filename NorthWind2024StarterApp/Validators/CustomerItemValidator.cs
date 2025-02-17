using FluentValidation;
using NorthWind2024StarterApp.Models;

namespace NorthWind2024StarterApp.Validators;

public class CustomerItemValidator : AbstractValidator<CustomerItem>
{
    public CustomerItemValidator()
    {
        Include(new CompanyNameValidator());
    }
}