using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;

internal class BookRepository : IBookRepository
{
    private readonly BookDbContext _dbContext;

    public BookRepository(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Book?> GetAsync(Guid id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

        return book;
    }

    public async Task<List<Book>> ListAsync()
    {
        var books = await _dbContext.Books.ToListAsync();

        return books;
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.AddAsync(book);
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await GetAsync(id);
        Guard.Against.Null(book);

        _dbContext.Remove(book);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
