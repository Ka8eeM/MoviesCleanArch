namespace Movies.Application.Commands.CreateMovie;

public sealed record CreateMovieResponse(
        Guid id,
        string movieName,
        string directorName,
        string releaseYear);