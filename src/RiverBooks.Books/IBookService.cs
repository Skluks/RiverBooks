namespace RiverBooks.Books;

internal interface IBookService
{
    Task<List<BookDto>> ListBooksAsync();
}
