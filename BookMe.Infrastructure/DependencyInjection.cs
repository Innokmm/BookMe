using BookMe.Application.Abstractions.Clock;
using BookMe.Application.Abstractions.Email;
using BookMe.Infrastructure.Clock;
using BookMe.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMe.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IEmailService, EmailService>();

        return services;
    }
}
