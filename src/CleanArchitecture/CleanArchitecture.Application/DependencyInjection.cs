using CleanArchitecture.Application.Abstractions.Behaviours;
using CleanArchitecture.Domain.Rents;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => 
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingBehaviour<,>));
        });
        services.AddTransient<PriceService>();
        return services;
    }
}