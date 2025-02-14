using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Common;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

/// <summary>
/// The services collection extension class.
/// </summary>
public static class ServicesCollectionExtension
{
    /// <summary>
    /// Adds the infrastructure using the specified builder.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        var services = builder.Services;
        services.AddDbContext<CompanyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
      
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IUinitOfWork, UnitOfWork>();
        return builder;
    }
}