using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Commands.CreateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddAutoMapper();
        //services.AddMediatR(typeof(CreateMovieCommandHandler).GetTypeInfo().Assembly);

        return services;
    }
}