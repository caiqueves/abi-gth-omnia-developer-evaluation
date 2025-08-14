using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;


public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedisService _redisService;

    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper,
        IUnitOfWork unitOfWork, IRedisService redisService, IRatingRepository ratingRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _redisService = redisService;
        _ratingRepository = ratingRepository;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingProduct = _productRepository.GetByIdAsync(Guid.Parse(command.Id), cancellationToken).Result;
        if (existingProduct is null)
            throw new ApplicationException($"Product for Id {command.Id} not found");

        existingProduct!.Rating!.Count = command.Count;
        existingProduct!.Rating!.Rate = command.Rate;

        await _ratingRepository.UpdateAsync(existingProduct.Rating, cancellationToken);

        var product = _mapper.Map<Product>(command);

        await _productRepository.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var updatedProduct = _productRepository.GetByIdAsync(product.Id, cancellationToken).Result;
        //bool connected = _redisService.TestConnection();
        //if (connected)
        //{
        //    _redisService.SetCache($"product:{product.Id}", JsonConvert.SerializeObject(updatedProduct));
        //}
        var result = _mapper.Map<UpdateProductResult>(updatedProduct);
        return result;
    }
}
