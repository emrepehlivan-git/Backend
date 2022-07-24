using Application.DTOs.Product;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<ProductsResponseDTO>>
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

        public async Task<ServiceResponse<ProductsResponseDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var found = await _productReadRespository.ExistsAsync(x => x.Id == request.Id);
            if (found == false)
                throw new Exception("Product not found");

            Product data = _mapper.Map<UpdateProductCommand, Product>(request);
            _productWriteRespository.Update(data);
            await _productWriteRespository.SaveAsync();
            ProductsResponseDTO response = _mapper.Map<ProductsResponseDTO>(data);

            return new ServiceResponse<ProductsResponseDTO>(response, true);
        }
    }
}
