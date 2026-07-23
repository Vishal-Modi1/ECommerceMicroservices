using Inventory.Domain.Entities;
using Inventory.Domain.Repository;
using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<InventoryEntity?> GetByProductIdAsync(Guid productId)
    {
        return await _context.Inventories
            .FirstOrDefaultAsync(x => x.ProductId == productId);
    }

    public async Task AddAsync(InventoryEntity inventory)
    {
        await _context.Inventories.AddAsync(inventory);
    }

    public void Update(InventoryEntity inventory)
    {
        _context.Inventories.Update(inventory);
    }
}