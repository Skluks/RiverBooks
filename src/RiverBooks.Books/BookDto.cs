namespace RiverBooks.Books;

internal class BookDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public string? Author { get; init; }

    public static BookDto ToBookDto(Book book)
    {
        return new BookDto { Id = book.Id, Author = book.Author, Title = book.Author };
    }
}
