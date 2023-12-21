using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class IncomeValidator : AbstractValidator<Income>
    {
        public IncomeValidator()
        {
            RuleFor(x => x.IncomeDate).NotEmpty().WithMessage("Income Date cannot be empty.");
            RuleFor(x => x.IncomePrice).NotEmpty().WithMessage("Income Price cannot be empty.");
            RuleFor(x => x.IncomePrice).GreaterThan(0).WithMessage("Price cannot be less than 0.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
        }
    }
}