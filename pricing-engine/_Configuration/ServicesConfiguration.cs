using index_engine.Services;

public static class ServicesConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IPricingService, PricingService>();

        return services;
    }
}