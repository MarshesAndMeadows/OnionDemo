using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Queries.GuestQuery;
using OnionDemo.Application.Queries.HostQuery;
using OnionDemo.Application.Queries.ReviewQuery;
using OnionDemo.Infrastructure.Queries;
using OnionDemo.Infrastructure.Repos;

namespace OnionDemo.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHostQuery, HostQuery>();
        services.AddScoped<IBookingQuery, BookingQuery>();
        services.AddScoped<IReviewQuery, ReviewQuery>();
        services.AddScoped<IGuestQuery, GuestQuery>();
        services.AddScoped<IUnitOfWork, UnitOfWork<BookMyHomeContext>>();
        services.AddScoped<IAccommodationRepository, AccommodationRepository>();
        services.AddScoped<IHostRepository, HostRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();

        // Database
        // https://github.com/dotnet/SqlClient/issues/2239
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
        // Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        // Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
        services.AddDbContext<BookMyHomeContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("BookMyHomeDbConnection"),
                x =>
                    x.MigrationsAssembly("OnionDemo.DatabaseMigration")));


        return services;
    }
}