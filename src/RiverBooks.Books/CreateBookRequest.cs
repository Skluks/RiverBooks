namespace RiverBooks.Books;

internal class CreateBookRequest
{
    public Guid? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public static BookDto ToBookDto(CreateBookRequest request)
    {
        return new BookDto
        {
            Id = request.Id ?? Guid.NewGuid(), Title = request.Title, Author = request.Author, Price = request.Price
        };
    }
}
