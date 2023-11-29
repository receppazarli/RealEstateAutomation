using FluentValidation;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

            RuleFor(x => x.NationalityId).NotEmpty().WithMessage("Nationality Id field cannot be empty").ToString();
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name field cannot be empty").ToString();
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name field cannot be empty").ToString();
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone field cannot be empty").ToString();

            //TODO fluent validation testi yaparken hata çıktı yarın ordan devam edilecek.

        }
    }
}