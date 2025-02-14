using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExtension
{
    
    public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var services = builder.Services;

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtension));
        });
        return builder;
    }
}