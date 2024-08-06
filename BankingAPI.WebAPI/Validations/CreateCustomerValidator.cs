using BankingAPI.Core.DTOs.Customers;
using FluentValidation;

namespace BankingAPI.WebAPI.Validations
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerValidator()
        {
            RuleFor(p=>p.FirstName)
                .MinimumLength(3)
                .WithMessage("First name must be at least 3 characters long")
                .MaximumLength(50)
                .WithMessage("First name must be at most 50 characters long");

            RuleFor(p=>p.LastName)
                .MinimumLength(3)
                .WithMessage("Last name must be at least 3 characters long")
                .MaximumLength(50)
                .WithMessage("Last name must be at most 50 characters long");

            RuleFor(p=>p.TCNumber)
                .Length(11)
                .WithMessage("TC number must be 11 characters long");

            RuleFor(p=>p.BirthPlace)
                .MinimumLength(3)
                .WithMessage("Birth place must be at least 3 characters long")
                .MaximumLength(50)
                .WithMessage("Birth place must be at most 50 characters long");

            RuleFor(p => p.BirthDate)
                .LessThan(DateTime.UtcNow)
                .WithMessage("Birth date must be less than today");

            RuleFor(p=> new { p.FirstName, p.LastName })
                .Must(p=>p.FirstName != p.LastName)
                .WithMessage("First name and last name cannot be the same")
                .Must(x => (x.FirstName.Length + x.LastName.Length) <= 100)
                .WithMessage("The sum of the lengths of the first name and last name must be less than or equal to 100");


     
        }
    }
}
