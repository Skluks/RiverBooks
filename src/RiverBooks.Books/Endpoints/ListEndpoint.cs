using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class ListEndpoint : EndpointWithoutRequest<ListBooksResponse>
{
    private readonly IBookService _bookService;

    public ListEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Get("books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var books = await _bookService.ListAsync();

        await Send.OkAsync(new ListBooksResponse { Books = books }, ct);
    }
}
