using Application.DTOs.Product;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Products.CreateProduct
{
     public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<ProductsResponseDTO>>
     {
          readonly IMapper _mapper;
          readonly IProductWriteRespository _productWriteRespository;

          public CreateProductCommandHandler (IMapper mapper, IProductWriteRespository repo)
          {
               _mapper = mapper;
               _productWriteRespository = repo;
          }

          public async Task<ServiceResponse<ProductsResponseDTO>> Handle (CreateProductCommand request, CancellationToken cancellationToken)
          {
               Product product = _mapper.Map<Product>(request);
               await _productWriteRespository.AddAsync(product);
               await _productWriteRespository.SaveAsync();
               var dto = _mapper.Map<ProductsResponseDTO>(product);
               var response = new ServiceResponse<ProductsResponseDTO>(dto, true);
               return await Task.FromResult(response);
          }
     }
}
