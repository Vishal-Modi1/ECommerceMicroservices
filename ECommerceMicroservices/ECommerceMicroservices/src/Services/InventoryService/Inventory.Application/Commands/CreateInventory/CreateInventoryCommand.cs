using MediatR;

namespace InventoryService.Application.Features.Inventory.Commands.CreateInventory;

public record CreateInventoryCommand(
    Guid ProductId,
    int AvailableQuantity
) : IRequest<Guid>;