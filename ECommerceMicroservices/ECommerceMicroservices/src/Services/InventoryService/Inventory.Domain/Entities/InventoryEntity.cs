using BuildingBlocks.Common.Entities;

namespace Inventory.Domain.Entities;

public class InventoryEntity : BaseEntity
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }

    public int AvailableQuantity { get; private set; }

    public byte[] RowVersion { get; private set; } = default!;

    private InventoryEntity() { }

    public InventoryEntity(Guid productId, int quantity)
    {
        ProductId = productId;
        AvailableQuantity = quantity;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public void Reserve(int quantity)
    {
        if (AvailableQuantity < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        AvailableQuantity -= quantity;
    }
}