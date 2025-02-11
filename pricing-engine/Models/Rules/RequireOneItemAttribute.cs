using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace index_pricing_services.Services;

public class RequireOneItemAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IList list && list?.Count < 0)
            return new ValidationResult("The list must contain at least one item.");

        return ValidationResult.Success!;
    }
}
