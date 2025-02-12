using index_engine.Services;
using Microsoft.Extensions.Caching.Memory;

namespace index_pricing_services._Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddMemoryCache();

        services.AddTransient<PricingService>();
        services.AddTransient(provider =>
        {
            var pricing = provider.GetRequiredService<PricingService>();
            var bridge = new SigningPricingServiceBridge(pricing);
            return bridge;
        });
        services.AddTransient<IPricingService>(provider =>
        {
            var service = provider.GetRequiredService<SigningPricingServiceBridge>();
            var cache = provider.GetRequiredService<IMemoryCache>();
            var bridge = new CachingPricingServiceAdapter(service, cache);
            return bridge;
        });

        return services;
    }
}