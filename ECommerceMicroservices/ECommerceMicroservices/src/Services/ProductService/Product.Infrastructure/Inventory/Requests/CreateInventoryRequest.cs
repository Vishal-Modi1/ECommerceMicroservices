namespace Product.Infrastructure.Services.Inventory.Requests;

public class CreateInventoryRequest
{
    public Guid ProductId { get; set; }

    public int AvailableQuantity { get; set; }
}