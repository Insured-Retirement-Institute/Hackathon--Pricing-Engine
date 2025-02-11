using index_engine.Models;

namespace index_engine.Services;

public interface IPricingService
{
    Task<PricingResult> Get(PricingRequest request);
}

public class PricingService : IPricingService
{
    public async Task<PricingResult> Get(PricingRequest request)
    {
        throw new NotImplementedException();
    }
}
