using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.AccommodationCommand;
using OnionDemo.Application.Command;

namespace OnionDemo.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookingCommand, BookingCommand>();
        services.AddScoped<IAccommodationCommand, AccommodationCommand.AccommodationCommand>();
        return services;
    }
}