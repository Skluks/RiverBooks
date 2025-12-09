using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class UpdatePriceEndpoint : Endpoint<Models.UpdatePriceRequest>
{
    private readonly IBookService _bookService;

    public UpdatePriceEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Patch("books/update-price");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.UpdatePriceRequest request, CancellationToken cancellationToken)
    {
        await _bookService.UpdatePriceAsync(request.Id, request.NewPrice);

        await Send.OkAsync(cancellationToken);
    }
}
