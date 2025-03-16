using MovieRatings.Application.Models;
using MovieRatings.Contracts.Requests;
using MovieRatings.Contracts.Responses;

namespace MovieRatings.Api.Mappers;

public static class ContractMapping
{
    public static Movie MapToMovie(this CreateMovieRequest createMovieRequest)
    {
        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = createMovieRequest.Title,
            YearOfRelease = createMovieRequest.YearOfRelease,
            Genres = createMovieRequest.Genres.ToList()
        };
    }

    public static MovieResponse MapToResponse(this Movie movie)
    {
        return new MovieResponse
        {
            Id = movie.Id,
            Title = movie.Title,
            Slug = movie.Slug,
            YearOfRelease = movie.YearOfRelease,
            Genres = movie.Genres
        };
    }

    public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies)
    {
        return new MoviesResponse
        {
            Movies = movies.Select(MapToResponse)
        };
    }

    public static Movie MapToMovie(this UpdateMovieRequest updateMovieRequest, Guid id)
    {
        return new Movie
        {
            Id = id,
            Title = updateMovieRequest.Title,
            YearOfRelease = updateMovieRequest.YearOfRelease,
            Genres = updateMovieRequest.Genres.ToList()
        };
    }
}