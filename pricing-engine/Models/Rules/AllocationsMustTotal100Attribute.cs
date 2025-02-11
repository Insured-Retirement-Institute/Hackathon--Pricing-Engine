using System.ComponentModel.DataAnnotations;
using static index_engine.Models.PricingRequest;

namespace index_pricing_services.Services;

public class AllocationsMustTotal100Attribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not IEnumerable<AllocationModel> allocations)
        {
            return new ValidationResult("Invalid collection.");
        }

        if (allocations.Sum(a => a.AllocationPercentage) != 100)
        {
            return new ValidationResult("Allocation percentages must total 100%.");
        }

        return ValidationResult.Success!;
    }
}
