using Inventory.Domain.Entities;

namespace Inventory.Domain.Repository;

public interface IInventoryRepository
{
    Task<InventoryEntity?> GetByProductIdAsync(Guid productId);

    Task AddAsync(InventoryEntity inventory);

    void Update(InventoryEntity inventory);
}