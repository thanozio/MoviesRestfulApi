using Microsoft.Extensions.DependencyInjection;
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
}