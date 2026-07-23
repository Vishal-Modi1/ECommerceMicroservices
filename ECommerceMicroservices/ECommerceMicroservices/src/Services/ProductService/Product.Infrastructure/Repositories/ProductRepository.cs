using Microsoft.EntityFrameworkCore;
using Product.Domain.Repositories;
using ProductEntity = Product.Domain.Entities.ProductEntity;
using Product.Infrastructure.Persistence;

namespace Product.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<ProductEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(ProductEntity product)
    {
        await _context.Products.AddAsync(product);
    }

    public void UpdateAsync(ProductEntity product)
    {
        _context.Products.Update(product);
    }

    public void DeleteAsync(ProductEntity product)
    {
        _context.Products.Remove(product);
    }
}