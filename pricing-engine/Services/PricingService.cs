using index_engine.Models;

namespace index_engine.Services;

public interface IPricingService
{
    Task<PricingResponse> Get(PricingRequest request);
}

public class PricingService : IPricingService
{
    public async Task<PricingResponse> Get(PricingRequest request)
    {
        throw new NotImplementedException();
    }
}
