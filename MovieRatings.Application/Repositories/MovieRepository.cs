﻿using MovieRatings.Application.Models;

namespace MovieRatings.Application.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movies = new();

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        var movie = _movies.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(movie);
    }

    public Task<Movie?> GetBySlugAsync(string slug)
    {
        var movie = _movies.FirstOrDefault(m => m.Slug == slug);
        return Task.FromResult(movie);
    }

    public Task<bool> CreateAsync(Movie movie)
    {
        _movies.Add(movie);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Movie>>(_movies);
    }

    public Task<bool> UpdateAsync(Movie movie)
    {
        var movieIndex = _movies.FindIndex(x => x.Id == movie.Id);
        if (movieIndex == -1)
            return Task.FromResult(false);

        _movies[movieIndex] = movie;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var indexToDelete = _movies.FindIndex(m => m.Id == id);
        if (indexToDelete == -1)
            return Task.FromResult(false);

        _movies.RemoveAt(indexToDelete);
        return Task.FromResult(true);
    }
}