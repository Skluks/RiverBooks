using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class GetByIdEndpoint : Endpoint<Models.GetByIdRequest, BookDto>
{
    private readonly IBookService _bookService;

    public GetByIdEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Get("/books/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.GetByIdRequest request, CancellationToken cancellationToken)
    {
        BookDto book = await _bookService.GetByIdAsync(request.Id);

        Response = book;
    }
}