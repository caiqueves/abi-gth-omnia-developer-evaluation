using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GerProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedisService _redisService;


    public GerProductHandler(IProductRepository productRepository, IMapper mapper, IRatingRepository ratingRepository,
       IUnitOfWork unitOfWork, IRedisService redisService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
        _redisService = redisService;
    }

    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductValidator();
        var product = new Product();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var productJson = _redisService.GetCache($"product:{request.Id}");

        //if (productJson != null)
        //{
        //    product = JsonConvert.DeserializeObject<Product>(productJson);
        //}
        //else
        //{
            product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
                throw new KeyNotFoundException($"User with ID {request.Id} not found",null);
            
            //bool connected = _redisService.TestConnection();
            //if (connected)
            //{
            //    _redisService.SetCache($"product:{product!.Id}", JsonConvert.SerializeObject(product));
            //}
        //}

        return _mapper.Map<GetProductResult>(product);
    }
}
