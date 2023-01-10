using CleanMovieDomain;

namespace CleanMovie.Application;

public interface IMovieService
{
    List<Movie> GetAllMovies();

    Movie CreateMovie(Movie movie);
}