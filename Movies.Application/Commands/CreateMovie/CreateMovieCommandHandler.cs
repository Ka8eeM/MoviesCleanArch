using MediatR;
using Movies.Application.Mappers;
using Movies.Core.Entites;
using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands.CreateMovie;

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieResponse>
{
    protected readonly IMovieRepository _movieRepository;
    public CreateMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<CreateMovieResponse> Handle(
        CreateMovieCommand request,
        CancellationToken cancellationToken)
    {
        var entity = MovieMapper.Mapper.Map<Movie>(request);
        if (entity is null)
        {
            // return result object instead of throwing exception
            throw new ApplicationException("there is an issue with mapping");
        }
        var newMovie = await _movieRepository.AddAsync(entity);
        var movieRepsone = MovieMapper.Mapper.Map<CreateMovieResponse>(newMovie);
        return movieRepsone!;

    }
}