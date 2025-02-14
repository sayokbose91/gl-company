namespace CompanyApi.Common;

public static class CorsExtensions
{
    /// <summary>
    /// Registers a CORS policy for your Angular client.
    /// </summary>
    public static IServiceCollection AddAngularCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularClient", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        return services;
    }

    /// <summary>
    /// Uses the Angular CORS policy in the middleware pipeline.
    /// </summary>
    public static IApplicationBuilder UseAngularCorsPolicy(this IApplicationBuilder app)
    {
        return app.UseCors("AllowAngularClient");
    }
}