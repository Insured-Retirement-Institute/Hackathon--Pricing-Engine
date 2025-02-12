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
            Rate = GetNewRate(minValue: 2.50F, maxValue: 5.00F)
        };

        var parFund = new PricingResponse.FundModel
        {
            FundName = $"{request.RequestorName} PAR Fund",
            Rate = GetNewRate(minValue: 80.0F, maxValue: 90.0F, digits: 1)
        };

        response.Funds.Add(capFund);
        response.Funds.Add(parFund);

        return Task.FromResult(response);
    }

    private static float GetNewRate(float minValue, float maxValue, int digits = 2)
    {
        var random = new Random();
        var rate = (float)random.NextDouble() * (maxValue - minValue) + minValue;
        var roundedRate = (float)Math.Round(rate, digits);
        return rate;
    }
}
