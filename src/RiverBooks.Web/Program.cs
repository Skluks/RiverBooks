using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Books;
using RiverBooks.Users;
using Serilog;
using ILogger = Serilog.ILogger;

ILogger logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting Web Host");

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
    config.ReadFrom.Configuration(builder.Configuration));

ConfigurationManager configurationManager = builder.Configuration;

builder.Services.AddBookService(configurationManager, logger);
builder.Services.AddUserService(configurationManager, logger);

builder.Services.AddFastEndpoints()
    .AddAuthenticationJwtBearer(o =>
    {
        o.SigningKey = builder.Configuration["Auth.JwtSecret"];
    })
    .AddAuthorization()
    .SwaggerDocument();

WebApplication app = builder.Build();

app.UseAuthentication()
    .UseAuthorization();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.UseOpenApi();
app.UseSwaggerUI();

app.Run();