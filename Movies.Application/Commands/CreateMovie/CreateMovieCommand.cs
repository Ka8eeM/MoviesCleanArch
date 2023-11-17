using MediatR;

namespace Movies.Application.Commands.CreateMovie;

public record CreateMovieCommand(
        string movieName,
        string directorName,
        string releaseYear) : IRequest<CreateMovieResponse>;
