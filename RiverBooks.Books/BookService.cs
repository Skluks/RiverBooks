namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        var books = new List<BookDto> { new(Guid.NewGuid(), "Potter", "Harry") };

        return books;
    }
}
