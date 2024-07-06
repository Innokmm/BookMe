using BookMe.Api.Extensions;
using BookMe.Application;
using BookMe.Infrastructure;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    CultureInfo[] supportedCultures = new[] { new CultureInfo("en-NZ") };
    options.DefaultRequestCulture = new RequestCulture("en-NZ");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddDateOnlyTimeOnlyStringConverters();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
    //app.SeedData();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

//app.UseAuthorization();

app.MapControllers();

app.Run();
