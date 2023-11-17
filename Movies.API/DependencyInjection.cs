using Microsoft.OpenApi.Models;

namespace Movies.API;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API Review", Version = "v1" });
        });
        return services;
    }

}
