using Inventory.Domain.Repository;
using Inventory.Domain.UnitOfWork;
using MediatR;

namespace Inventory.Application.Commands.CreateInventory;

public class ReserveInventoryCommandHandler : IRequestHandler<ReserveInventoryCommand>
{
    private readonly IInventoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task Handle(
        ReserveInventoryCommand request,
        CancellationToken cancellationToken)
    {
        var inventory =
            await _repository.GetByProductIdAsync(request.ProductId);

        if (inventory is null)
            throw new Exception("Product not found.");

        inventory.Reserve(request.Quantity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}