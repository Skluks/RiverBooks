namespace RiverBooks.Books;

internal interface IReadonlyBookRepository
{
    Task<Book?> GetAsync(Guid id);
    Task<List<Book>> ListAsync();
}
