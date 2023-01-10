using CleanMovie.Application;
using CleanMovieDomain;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController (IMovieService movieService)
    {
        _movieService = movieService;
    }
    [HttpGet]
    public ActionResult<List<Movie>> Get()
    {
        var moviesFromService = _movieService.GetAllMovies();
        return Ok(moviesFromService);
    }

    [HttpPost]
    public ActionResult<Movie> PostMovie(Movie movie)
    {
        var Movie = _movieService.CreateMovie(movie);
        return Ok(Movie);
    }
}