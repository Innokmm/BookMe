using BookMe.Application.Abstractions.Clock;
using BookMe.Application.Abstractions.Email;
using BookMe.Infrastructure.Clock;
using BookMe.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMe.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IEmailService, EmailService>();

        string connectionString = configuration.GetConnectionString("Database") ?? 
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
