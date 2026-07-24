namespace Product.Application.Common.Interfaces;

public interface IInventoryService
{
    Task CreateInventoryAsync(
        Guid productId,
        int availableQuantity,
        CancellationToken cancellationToken = default);
}