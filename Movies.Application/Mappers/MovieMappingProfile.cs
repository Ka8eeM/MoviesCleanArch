using AutoMapper;
using Movies.Application.Commands.CreateMovie;
using Movies.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Mappers;

public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Movie, CreateMovieResponse>()
            .ReverseMap();

        CreateMap<Movie, CreateMovieCommand>()
            .ReverseMap();
    }
}