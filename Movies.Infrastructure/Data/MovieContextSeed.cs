using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Data;

public class MovieContextSeed
{
    public static async Task SeedAsync(
        MovieContext movieContext,
        ILoggerFactory loggerFactory,
        int? retry = 0)
    {
        int retryForAvailable = retry.Value;
        try
        {
            await movieContext.Database.EnsureCreatedAsync();

            if (!await movieContext.Movies.AnyAsync())
            {
                movieContext.Movies.AddRangeAsync(setMovies());
                await movieContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailable < 3)
            {
                retryForAvailable++;
                var log = loggerFactory.CreateLogger<MovieContextSeed>();
                log.LogError($"Exception occured while connectoin: {ex.Message}");
                await SeedAsync(movieContext, loggerFactory, retryForAvailable);
            }
        }
    }

    private static IEnumerable<Movie> setMovies()
    {

        return new List<Movie>()
        {
            Movie.Create("Avatar", "James", "2009"),
            Movie.Create("Titanic", "James", "1997"),
            Movie.Create("Si", "Lee", "2002"),
            Movie.Create("Godzilla", "Eric", "2014"),
        };
    }
}