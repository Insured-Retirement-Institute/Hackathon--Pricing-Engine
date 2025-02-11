using System.ComponentModel.DataAnnotations;
using static index_engine.Models.PricingRequest;

namespace index_pricing_services.Services;

public class AllocationsMustBeUnique : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not IEnumerable<AllocationModel> allocations)
        {
            return new ValidationResult("Invalid collection.");
        }

        //error if allocations are not unique
        var totalAllocations = allocations.Count();
        var distinctAllocations = allocations
            .DistinctBy(a => new
            {
                a.AssetClass,
                a.AssetId
            })
            .Count();

        if (distinctAllocations != totalAllocations)
        {
            return new ValidationResult("Allocations must be unique.");
        }

        return ValidationResult.Success!;
    }
}