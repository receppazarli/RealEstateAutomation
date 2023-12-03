using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class FieldValidator : AbstractValidator<Field>
    {
        public FieldValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner space cannot be empty.");
            RuleFor(x => x.Area).NotEmpty().WithMessage("Area cannot be empty.");
            RuleFor(x => x.Area).GreaterThan(0).WithMessage("Area cannot be less than 0.");
            RuleFor(x => x.Pafta).NotEmpty().WithMessage("Pafta cannot be empty.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City cannot be empty.");
            RuleFor(x => x.County).NotEmpty().WithMessage("County cannot be empty.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price cannot be less than 0.");
            

        }

    }
}