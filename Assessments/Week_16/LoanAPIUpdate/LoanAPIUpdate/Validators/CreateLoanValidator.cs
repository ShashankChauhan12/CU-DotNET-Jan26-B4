using FluentValidation;
using LoanAPIUpdate.DTOs;

namespace LoanAPIUpdate.Validators
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanDto>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0);

            RuleFor(x => x.Amount)
                .GreaterThan(50000);

            RuleFor(x => x.LoanType)
                .NotEmpty();

            RuleFor(x => x.TermInMonths)
                .InclusiveBetween(6, 48);

            RuleFor(x => x.Purpose)
                .MaximumLength(100);
        }
    }
}
