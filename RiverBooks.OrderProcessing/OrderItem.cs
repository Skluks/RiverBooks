namespace RiverBooks.OrderProcessing;

internal class OrderItem
{
    public OrderItem(Guid id, Guid bookId, int quantity, decimal unitPrice, string description)
    {
        Id = id;
        BookId = bookId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Description = description;
    }

    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Description { get; set; }
}