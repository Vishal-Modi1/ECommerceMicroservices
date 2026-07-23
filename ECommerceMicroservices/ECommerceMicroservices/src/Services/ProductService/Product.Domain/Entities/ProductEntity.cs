using BuildingBlocks.Common.Entities;

namespace Product.Domain.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    private ProductEntity()
    {
        // Required by EF Core
    }

    public ProductEntity(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public void UpdatePrice(decimal price)
    {
        Price = price;
        ModifiedOnUtc = DateTime.UtcNow;
    }
}