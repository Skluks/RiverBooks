using FastEndpoints;

namespace RiverBooks.Books;

public class GetByIdRequest
{
    [BindFrom("id")] public Guid Id { get; set; }
}
