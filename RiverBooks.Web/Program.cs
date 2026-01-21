using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Books;
using RiverBooks.OrderProcessing;
using RiverBooks.Users;
using Serilog;
using ILogger = Serilog.ILogger;

ILogger logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddFastEndpoints()
    .AddJWTBearerAuth(builder.Configuration["Auth:JwtSecret"]!)
    .AddAuthorization()
    .SwaggerDocument();

// Add Module Services
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.Services.AddBookModuleServices(builder.Configuration, logger, mediatRAssemblies);
builder.Services.AddUserModuleServices(builder.Configuration, logger, mediatRAssemblies);
builder.Services.AddOrderProcessingModuleServices(builder.Configuration, logger, mediatRAssemblies);

// Set up MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));


WebApplication app = builder.Build();

app.UseAuthentication()
    .UseAuthorization();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

public partial class Program
{
} // needed for tests