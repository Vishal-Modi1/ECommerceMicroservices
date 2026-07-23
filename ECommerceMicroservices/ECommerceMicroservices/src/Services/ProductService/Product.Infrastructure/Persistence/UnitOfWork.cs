using Product.Domain.UnitOfWork;

namespace Product.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductDbContext _context;

    public UnitOfWork(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}