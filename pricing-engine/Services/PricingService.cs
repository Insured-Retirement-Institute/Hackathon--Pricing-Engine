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
        var response = new PricingResponse()
        {
            ValidUntilDate = expiration
        };

        var capFund = new PricingResponse.FundModel
        {
            FundName = $"{request.RequestorName} CAP Fund",
            Rate = 4F
        };

        var parFund = new PricingResponse.FundModel
        {
            FundName = $"{request.RequestorName} PAR Fund",
            Rate = 80F
        };

        response.Funds.Add(capFund);
        response.Funds.Add(parFund);

        return Task.FromResult(response);
    }
}
