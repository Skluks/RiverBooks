namespace RiverBooks.Books;

public class UpdatePriceRequest
{
    public Guid Id { get; set; }
    public decimal NewPrice { get; set; }
}
