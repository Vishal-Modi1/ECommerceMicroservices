using Inventory.Application.Commands.CreateInventory;
using InventoryService.Application.Features.Inventory.Commands.CreateInventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Coontrollers;

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

    [HttpPost]
    public async Task<IActionResult> Create(CreateInventoryCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), new { id }, id);
    }
}