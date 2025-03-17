using Microsoft.Extensions.DependencyInjection;
using MovieRatings.Application.Database;
using MovieRatings.Application.Repositories;

namespace MovieRatings.Application;

/*
 * Responsible for adding services in the DI,
 * to the service addition in its appropriate layer.
 */
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        // since it generates a new connection factory every time
        // this is a Singleton that basically masks a transient 
        services.AddSingleton<IDbConnectionFactory>(_ =>
            new NpgsqlConnectionFactory(connectionString));

        return services;
    }
}