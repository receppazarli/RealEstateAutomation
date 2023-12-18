using FluentValidation;
using RealEstateAutomation.Entities.Concrete;
using System.Diagnostics;

namespace RealEstateAutomation.Business.ValidationRules.FluentValidation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.SalePropertyId).NotEmpty().WithMessage("Property cannot be empty, please select a property");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer cannot be empty, please select a customer");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Price cannot be empty, please entry price");
            RuleFor(x => x.SalePrice).GreaterThan(0).WithMessage("Price cannot be less than 0");
        }
    }
}