using index_engine.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace index_engine.Services;

public class CachingPricingServiceAdapter(IPricingService pricing, IMemoryCache cache) : IPricingService
{
    public async Task<PricingResponse> Get(PricingRequest request)
    {
        var key = GetKey(request);
        var response = await cache.GetOrCreateAsync(key, async entry =>
            await pricing.Get(request))
            ?? throw new Exception("Could not retrieve new prices.");

        return response;
    }

    private static string GetKey(PricingRequest request)
    {
        var requestJson = JsonSerializer.Serialize(request);
        var encodedData = Encoding.UTF8.GetBytes(requestJson);
        var bytes = MD5.HashData(encodedData);
        var key = string.Concat(bytes.Select(b => b.ToString("x2")));
        return key;
    }
}