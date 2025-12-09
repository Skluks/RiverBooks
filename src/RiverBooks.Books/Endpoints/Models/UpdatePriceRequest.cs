namespace RiverBooks.Books.Endpoints.Models;

public class UpdatePriceRequest
{
    public Guid Id { get; set; }
    public decimal NewPrice { get; set; }
}
