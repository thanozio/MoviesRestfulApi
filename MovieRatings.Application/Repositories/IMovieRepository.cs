using MovieRatings.Application.Models;

namespace MovieRatings.Application.Repositories;

public interface IMovieRepository
{
    Task<Movie?> GetByIdAsync(Guid id);

    Task<Movie?> GetBySlugAsync(string slug);

    Task<bool> CreateAsync(Movie movie);

    Task<IEnumerable<Movie>> GetAllAsync();

    Task<bool> UpdateAsync(Movie movie);

    Task<bool> DeleteByIdAsync(Guid id);
}