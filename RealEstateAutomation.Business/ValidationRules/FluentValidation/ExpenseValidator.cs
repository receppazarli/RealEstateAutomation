using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {

            RuleFor(x => x.ExpenseDate).NotEmpty().WithMessage("Income Date cannot be empty.");
            RuleFor(x => x.ExpensePrice).NotEmpty().WithMessage("Income Price cannot be empty.");
            RuleFor(x => x.ExpensePrice).GreaterThan(0).WithMessage("Price cannot be less than 0.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}