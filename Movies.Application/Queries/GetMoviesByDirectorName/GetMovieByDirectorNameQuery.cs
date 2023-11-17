using MediatR;

namespace Movies.Application.Queries.GetMoviesByDirectorName;

public record GetMovieByDirectorNameQuery(string directoryName) : IRequest<List<GetMovieByDirectorNameQueryResponse>>;