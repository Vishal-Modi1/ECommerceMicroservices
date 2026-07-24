using MediatR;

namespace Inventory.Application.Commands.CreateInventory;

public record ReserveInventoryCommand(Guid ProductId, int Quantity) : IRequest;