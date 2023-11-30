using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.NationalityId).MaximumLength(11).WithMessage("Please enter the correct Nationality ID");
            RuleFor(x => x.NationalityId).MinimumLength(11).WithMessage("Please enter the correct Nationality ID");
            RuleFor(x => x.NationalityId).NotEmpty().WithMessage("Nationality Id field cannot be empty");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name field cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name field cannot be empty");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone field cannot be empty");



        }
    }
}