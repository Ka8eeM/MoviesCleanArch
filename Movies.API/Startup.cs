namespace Movies.API;

public class Startup
{
    public IConfiguration Configuration;
    public Startup(IConfiguration configuration)
    {
        configuration = configuration;
    }

    public void ConfigureService(IServiceCollection services)
    {
        services.AddControllers();
        services.AddApiVersioning();
    }
}