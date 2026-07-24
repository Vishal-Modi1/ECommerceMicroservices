using Inventory.Domain.Entities;
using Inventory.Domain.Repository;
using Inventory.Domain.UnitOfWork;
using MediatR;

namespace InventoryService.Application.Features.Inventory.Commands.CreateInventory;

public class CreateInventoryCommandHandler
    : IRequestHandler<CreateInventoryCommand, Guid>
{
    private readonly IInventoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryCommandHandler(
        IInventoryRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        CreateInventoryCommand request,
        CancellationToken cancellationToken)
    {
        var inventory = new InventoryEntity(
            request.ProductId,
            request.AvailableQuantity);

        await _repository.AddAsync(inventory);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return inventory.Id;
    }
}