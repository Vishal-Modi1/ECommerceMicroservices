using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using Product.Application.Commands.CreateProduct;

namespace Product.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Name, request.Price);

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}