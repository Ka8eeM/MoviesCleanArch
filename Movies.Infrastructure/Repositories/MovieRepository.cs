using Microsoft.EntityFrameworkCore;
using Movies.Core.Entites;
using Movies.Core.Repositories;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories.Base;

namespace Movies.Infrastructure.Repositories;

internal class MovieRepository : Repository<Movie>, IMovieRepository
{

    public MovieRepository(MovieContext movieContext) : base(movieContext)
    {
    }

    public async Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string directorName)
    {
        return await _movieContext
            .Movies
            .Where(m => m.DirectorName == directorName)
            .ToListAsync();
    }
}
