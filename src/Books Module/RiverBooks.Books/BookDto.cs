namespace RiverBooks.Books;

internal class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal Price { get; set; }

    public static BookDto ToBookDto(Book book)
    {
        return new BookDto { Id = book.Id, Author = book.Author, Title = book.Title, Price = book.Price };
    }
}
