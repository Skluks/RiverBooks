using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class DeleteEndpoint : Endpoint<Models.DeleteBookRequest>
{
    private readonly IBookService _bookService;

    public DeleteEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Delete("/books/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.DeleteBookRequest request, CancellationToken cancellationToken)
    {
        await _bookService.DeleteAsync(request.Id);

        await Send.NoContentAsync(cancellationToken);
    }
}
