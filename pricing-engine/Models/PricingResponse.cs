using System.ComponentModel.DataAnnotations;

namespace index_engine.Models;

public class PricingResponse
{
    public string Hash { get; set; }
    public DateTime ValidUntilDate { get; set; }
    public List<FundModel> Funds { get; set; } = [];

    public class FundModel
    {
        public string FundName { get; set; }
        public RateTypeType RateType { get; set; }
        public float Rate { get; set; }

        public enum RateTypeType
        {
            CAP,
            Participation
        }
    }
}