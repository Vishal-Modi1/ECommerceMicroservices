using BuildingBlocks.Common.Results;
using MediatR;
using Product.Domain.Entities;
using Product.Domain.Repositories;
using Product.Domain.UnitOfWork;

namespace Product.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new ProductEntity(request.Name, request.Price);

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(product.Id);
    }
} 