using Product.Domain.Entities;

namespace Product.Domain.Repositories;

public interface IProductRepository
{
    Task<ProductEntity?> GetByIdAsync(Guid id);

    Task<IEnumerable<ProductEntity>> GetAllAsync();

    Task AddAsync(ProductEntity product);

    void UpdateAsync(ProductEntity product);

    void DeleteAsync(ProductEntity product);
}