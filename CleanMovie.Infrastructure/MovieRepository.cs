using CleanMovie.Application;
using CleanMovieDomain;

namespace CleanMovie.Infrastructure;

public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext) 
    {
        _movieDbContext = movieDbContext; 
    }

    public List<Movie> GetAllMovies()
    {
        return _movieDbContext.Movies.ToList();
    }

    public Movie CreateMovie(Movie movie) 
    {
        _movieDbContext.Movies.Add(movie);
        _movieDbContext.SaveChanges();

        return movie;
    }

}