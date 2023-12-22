using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
           // RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name cannot be empty.");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Password cannot be empty.");
        }

    }
}