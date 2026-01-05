using Ardalis.GuardClauses;

namespace RiverBooks.Books;

internal class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> ListAsync()
    {
        var books = await _bookRepository.ListAsync();

        var bookDtos = books.Select(BookDto.ToBookDto).ToList();

        return bookDtos;
    }

    public async Task<BookDto> GetByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            Guard.Against.Null(book);
        }

        return BookDto.ToBookDto(book);
    }

    public async Task CreateAsync(BookDto newBook)
    {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);

        await _bookRepository.AddAsync(book);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var bookToDelete = await _bookRepository.GetAsync(id);

        if (bookToDelete is null)
        {
            return;
        }

        await _bookRepository.DeleteAsync(id);
        await _bookRepository.SaveChangesAsync();
    }

    public async Task UpdatePriceAsync(Guid id, decimal price)
    {
        var book = await _bookRepository.GetAsync(id);

        if (book is null)
        {
            return;
        }

        book.UpdatePrice(price);
        await _bookRepository.SaveChangesAsync();
    }
}
