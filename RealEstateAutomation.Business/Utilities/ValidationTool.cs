using FluentValidation;
using System.Linq;

namespace RealEstateAutomation.Business.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            // var result = validator.Validate(entity as IValidationContext);

            if (result.Errors.Count > 0)
            {
                // throw new ValidationException(result.Errors.ToString());

                var errorMessages = result.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}\n").ToArray();
                string combinedErrorMessage = string.Join("", errorMessages);
                throw new ValidationException(combinedErrorMessage);
            }
        }
    }
}