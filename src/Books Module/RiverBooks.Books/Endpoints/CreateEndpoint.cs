using FastEndpoints;

namespace RiverBooks.Books.Endpoints;

internal class CreateEndpoint : Endpoint<Models.CreateBookRequest, BookDto>
{
    private readonly IBookService _bookService;

    public CreateEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override void Configure()
    {
        Post("books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Models.CreateBookRequest request, CancellationToken cancellationToken)
    {
        var bookDto = Models.CreateBookRequest.ToBookDto(request);

        await _bookService.CreateAsync(bookDto);

        await Send.CreatedAtAsync<GetByIdEndpoint>(bookDto.Id, bookDto, cancellation: cancellationToken);
    }
}
