using MediatR;
using Movies.Application.Mappers;
using Movies.Core.Entites;
using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries.GetMoviesByDirectorName;

internal sealed class GetMoviesByDirectorNameQueryHandler :
    IRequestHandler<GetMovieByDirectorNameQuery, List<GetMovieByDirectorNameQueryResponse>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMoviesByDirectorNameQueryHandler(
        IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<List<GetMovieByDirectorNameQueryResponse>> Handle(
        GetMovieByDirectorNameQuery request, 
        CancellationToken cancellationToken)
    {
        var movieList = await _movieRepository.GetMoviesByDirectorNameAsync(request.directoryName);
        var movieResponseList = MovieMapper.Mapper.Map<List<GetMovieByDirectorNameQueryResponse>>(movieList);
        return movieResponseList;
    }
}
