using index_engine.Models;

namespace index_engine.Services;

public interface IPricingService
{
    Task<PricingResponse> Get(PricingRequest request);
}

public class PricingService : IPricingService
{
    public Task<PricingResponse> Get(PricingRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var today = DateTime.UtcNow;
        var expiration = today.AddDays(2);

        //return fake model
        var response = new PricingResponse()
        {
            ValidUntilDate = expiration,
            MinimumIssueAge = 25,
            MaximumIssueAge = 80,
            SurrenderSchedule = [ ],
            PremiumLimits = [ ],
            Funds = [ ]
        };

        return Task.FromResult(response);
    }
}
