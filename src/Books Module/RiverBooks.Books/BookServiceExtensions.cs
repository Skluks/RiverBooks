using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookService(this IServiceCollection services, ConfigurationManager config, Serilog.ILogger logger)
    {
        string? connectionString = config.GetConnectionString("BooksConnectionString");
        services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookRepository, BookRepository>();

        logger.Information("{Module} module services registered", "Books");

        return services;
    }
}