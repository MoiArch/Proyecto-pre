using Web.API.Middlewares;

namespace Web.API;

public static class DependecyInjecttion
{
    public static IServiceCollection AddPesentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
        return services;
    }
}