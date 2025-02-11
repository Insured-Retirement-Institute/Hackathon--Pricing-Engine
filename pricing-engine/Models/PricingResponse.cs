using System.ComponentModel.DataAnnotations;

namespace index_engine.Models;

public class PricingResponse
{
    public string Hash { get; set; }
    public DateTime ValidUntilDate { get; set; }
    public int MinimumIssueAge { get; set; }
    public int MaximumIssueAge { get; set; }
    public List<FundModel> Funds { get; set; } = [];
    public List<SurrenderScheduleItem> SurrenderSchedule { get; set; } = [];
    public List<PremiumLimit> PremiumLimits { get; set; } = [];

    public class FundModel
    {
        public string FundName { get; set; }
        public float CAP { get; set; }
        public float ParticipationRate { get; set; }
    }

    public class SurrenderScheduleItem
    {
        public int Duration { get; set; }
        public float SurrenderPercentage { get; set; }
    }

    public class PremiumLimit
    {
        public int FromAge { get; set; }
        public int ThroughAge { get; set; }
        public float MinimumPremium { get; set; }
        public float MaximumPremium { get; set; }
    }
}