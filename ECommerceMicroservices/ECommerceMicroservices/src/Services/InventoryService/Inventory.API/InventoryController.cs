using Inventory.Application.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("reserve")]
    public async Task<IActionResult> Reserve(ReserveInventoryCommand command)
    {
        await _mediator.Send(command);

        return Ok(new
        {
            Message = "Inventory reserved successfully."
        });
    }
}