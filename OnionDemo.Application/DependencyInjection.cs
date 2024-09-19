using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Commands.AccommodationCommand;

namespace OnionDemo.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAccommodationCommand, AccommodationCommand>();
        return services;
    }
}