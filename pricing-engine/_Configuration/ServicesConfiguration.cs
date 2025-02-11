using index_engine.Services;

namespace index_pricing_services._Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<PricingService>();
        services.AddTransient<IPricingService>(provider =>
        {
            var service = provider.GetRequiredService<PricingService>();
            var bridge = new SigningPricingServiceBridge(service);
            return bridge;
        });

        return services;
    }
}