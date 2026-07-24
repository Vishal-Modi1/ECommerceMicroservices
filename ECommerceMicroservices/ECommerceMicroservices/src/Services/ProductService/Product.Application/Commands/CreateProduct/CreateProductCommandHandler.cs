using BuildingBlocks.Common.Results;
using MediatR;
using Product.Application.Common.Interfaces;
using Product.Domain.Entities;
using Product.Domain.Repositories;
using Product.Domain.UnitOfWork;

namespace Product.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInventoryService _inventoryService;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IInventoryService inventoryService)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _inventoryService = inventoryService;
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new ProductEntity(request.Name, request.Price);

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _inventoryService.CreateInventoryAsync(product.Id, 10, cancellationToken);

        return Result<Guid>.Success(product.Id);
    }
} 