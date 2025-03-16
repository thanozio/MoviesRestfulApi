using Microsoft.AspNetCore.Mvc;
using MovieRatings.Api.Mappers;
using MovieRatings.Application.Models;
using MovieRatings.Application.Repositories;
using MovieRatings.Contracts.Requests;

namespace MovieRatings.Api.Controllers;

[ApiController]
public class MoviesController(IMovieRepository movieRepository) : ControllerBase
{
    [HttpPost]
    [Route(ApiEndpoints.Movies.Create)]
    public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
    {
        var movie = request.MapToMovie();
        var success = await movieRepository.CreateAsync(movie);
        var movieResponse = movie.MapToResponse();
        return CreatedAtAction(nameof(GetMovieById), new { idOrSlug = movieResponse.Id }, movieResponse);
    }

    [HttpGet]
    [Route(ApiEndpoints.Movies.Get)]
    public async Task<IActionResult> GetMovieById([FromRoute] string idOrSlug)
    {
        Movie? movie;
        if (Guid.TryParse(idOrSlug, out var id))
            movie = await movieRepository.GetByIdAsync(id);
        else
            movie = await movieRepository.GetBySlugAsync(idOrSlug);

        if (movie is null) return NotFound();
        return Ok(movie.MapToResponse());
    }

    [HttpGet]
    [Route(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAllMovies()
    {
        var movies = await movieRepository.GetAllAsync();
        return Ok(movies.MapToResponse());
    }

    [HttpPut]
    [Route(ApiEndpoints.Movies.Update)]
    public async Task<IActionResult> UpdateMovie([FromRoute] Guid id, [FromBody] UpdateMovieRequest updateMovieRequest)
    {
        var movie = updateMovieRequest.MapToMovie(id);
        var movieUpdated = await movieRepository.UpdateAsync(movie);
        if (!movieUpdated) return NotFound();

        return Ok(movie.MapToResponse());
    }

    [HttpDelete]
    [Route(ApiEndpoints.Movies.Delete)]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        var isMovieDeleted = await movieRepository.DeleteByIdAsync(id);
        // This could return NoContent for both cases
        return isMovieDeleted ? NoContent() : NotFound();
    }
}