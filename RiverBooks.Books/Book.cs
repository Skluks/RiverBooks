namespace RiverBooks.Books;

internal class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    public Book(Guid id, string title, string author, decimal price)
    {
        Id = id;
        Title = title;
        Author = author;
        Price = price;
    }
}
