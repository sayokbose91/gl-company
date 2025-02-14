using Domain.Models;
using FluentValidation;

namespace Application.CompanyApp.Validators;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Exchange).NotEmpty();
        RuleFor(x => x.Ticker).NotEmpty();
        RuleFor(x => x.Isin)
            .NotEmpty()
            .Matches("^(?=.{12}$)[A-Za-z]{2}[0-9A-Za-z]{10}$")
            .WithMessage("ISIN must be exactly 12 characters long and start with two letters.");
        // Optional: Website can be validated if needed.
    }
}
