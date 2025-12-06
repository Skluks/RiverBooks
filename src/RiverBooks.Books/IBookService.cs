namespace RiverBooks.Books;

internal interface IBookService
{
    Task<List<BookDto>> ListAsync();
    Task<BookDto> GetByIdAsync(Guid id);
    Task CreateAsync(BookDto book);
    Task DeleteAsync(Guid id);
    Task UpdatePriceAsync(Guid id, decimal newPrice);
}
