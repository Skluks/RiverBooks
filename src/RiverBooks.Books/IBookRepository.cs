namespace RiverBooks.Books;

internal interface IBookRepository : IReadonlyBookRepository
{
    Task AddAsync(Book book);
    Task DeleteAsync(Guid bookId);
    Task Update(Book book);
    Task SaveChangesAsync();
}
