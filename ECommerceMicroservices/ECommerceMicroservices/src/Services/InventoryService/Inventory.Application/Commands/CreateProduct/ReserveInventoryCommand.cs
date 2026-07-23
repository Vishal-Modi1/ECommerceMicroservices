using MediatR;

namespace Inventory.Application.Commands.CreateProduct;

public record ReserveInventoryCommand(Guid ProductId, int Quantity) : IRequest;