using FastEndpoints;

namespace RiverBooks.Books.Endpoints.Models;

public class GetByIdRequest
{
    [BindFrom("id")] public Guid Id { get; set; }
}
