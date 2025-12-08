using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class ListBooksEndpoint(IBookService bookService) : EndpointWithoutRequest<ListBooksResponse>
{
    public override void Configure()
    {
        Get("books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var books = await bookService.ListAsync();

        await Send.OkAsync(new ListBooksResponse { Books = books }, ct);
    }
}
