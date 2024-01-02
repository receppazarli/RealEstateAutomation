using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Password cannot be empty.");
        }

    }
}