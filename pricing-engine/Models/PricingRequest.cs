using System.ComponentModel.DataAnnotations;

namespace index_engine.Models;

public class PricingRequest
{
    [Required]
    public string RequestorName { get; set; }

    [Required]
    public int ContractDuration { get; set; }

    [RequireOneItem]
    public List<AllocationModel> Allocations { get; set; }

    public class AllocationModel
    {
        [Required]
        [EnumDataType(typeof(AssetClassType))]
        public string AssetClass { get; set; }

        [Required]
        public string AssetId { get; set; }

        [Required]
        [Range(0, 100)]
        public int AllocationPercentage { get; set; }

        public enum AssetClassType
        {
            Stock,
            Bond,
            MutualFund
        }
    }
}
