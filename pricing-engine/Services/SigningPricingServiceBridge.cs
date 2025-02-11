using index_engine.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace index_engine.Services;

public class SigningPricingServiceBridge(IPricingService pricing) : IPricingService
{
    public async Task<PricingResponse> Get(PricingRequest request)
    {
        var response = await pricing.Get(request);
        response.Hash = null!;
        response.Hash = GetSigningHash(response);
        return response;
    }

    private static string GetSigningHash(PricingResponse payload)
    {
        ArgumentNullException.ThrowIfNull(payload);

        var requestJson = JsonSerializer.Serialize(payload);
        var bytes = Encoding.UTF8.GetBytes(requestJson);
        var hashBytes = SHA256.HashData(bytes);
        var hash = string.Concat(bytes.Select(b => b.ToString("x2")));

        return hash;
    }
}