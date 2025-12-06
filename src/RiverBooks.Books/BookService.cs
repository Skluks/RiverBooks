namespace RiverBooks.Books;

internal class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        var books = await _bookRepository.ListAsync();

        var bookDtos = books.Select(BookDto.ToBookDto).ToList();

        return bookDtos;
    }
}
