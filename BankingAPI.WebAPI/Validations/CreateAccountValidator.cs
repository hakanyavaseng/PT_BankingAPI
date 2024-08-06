using BankingAPI.Core.DTOs.Accounts;
using BankingAPI.Core.Entities;
using FluentValidation;

namespace BankingAPI.WebAPI.Validations
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountValidator()
        {
            RuleFor(p => p.AccountName)
                .MinimumLength(3)
                .WithMessage("Account name must be at least 3 characters long")
                .MaximumLength(50)
                .WithMessage("Account name must be at most 50 characters long");

            RuleFor(p=>p.Balance)
                .GreaterThan(0)
                .WithMessage("Balance must be greater than 0");

            RuleFor(p=>p.CustomerId)
                .GreaterThan(0)
                .WithMessage("Customer Id must be greater than 0");         
        }
    }

}
