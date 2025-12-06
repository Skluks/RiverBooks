using FastEndpoints;

namespace RiverBooks.Books;

public class ListBooksEndpoint(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    public override void Configure()
    {
        Get("books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var books = bookService.ListBooks();

        await Send.OkAsync(new ListBooksResponse { Books = books }, ct);
    }
}
