namespace BookMe.Application.Abstractions.Email;

internal interface IEmailService
{
    Task SendEmailAsync(Domain.Users.Email recipient, string subject, string body);
}