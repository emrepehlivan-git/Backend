using Application.DTOs.Product;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Products.UpdateProduct
{
     public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponseDTO>
     {
          readonly IMapper _mapper;
          readonly IProductWriteRespository _productWriteRespository;
          readonly IProductReadRepository _productReadRespository;
          public UpdateProductCommandHandler(IMapper mapper, IProductWriteRespository productWriteRespository, IProductReadRepository productReadRespository)
          {
               _mapper = mapper;
               _productWriteRespository = productWriteRespository;
               _productReadRespository = productReadRespository;
          }

          public async Task<UpdateProductResponseDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
          {
               try
               {
                    Product product = await _productReadRespository.GetByIdAsync(request.Id);
                    Product data = _mapper.Map<UpdateProductCommand, Product>(request, product);
                    _productWriteRespository.Update(data);
                    await _productWriteRespository.SaveAsync();
                    UpdateProductResponseDTO response = _mapper.Map<UpdateProductResponseDTO>(product);
                    return await Task.FromResult(response);
               }
               catch (Exception e)
               {
                    throw new Exception($"Error: {e.Message}");
               }
          }
     }
}
