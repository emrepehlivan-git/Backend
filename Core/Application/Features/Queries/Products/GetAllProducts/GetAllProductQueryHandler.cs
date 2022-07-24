using Application.DTOs.Product;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ServiceResponse<List<ProductsResponseDTO>>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ProductsResponseDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var Count = await _productReadRepository.CountAsync();
            var data = _productReadRepository.GetAll().Include(x => x.Category).Skip(request.Page * request.PageSize).Take(request.PageSize).ToList();
            List<ProductsResponseDTO> dto = _mapper.Map<List<ProductsResponseDTO>>(data);
            var response = new PagedResponse<List<ProductsResponseDTO>>(dto, request.Page, request.PageSize, Count, true);
            return await Task.FromResult(response);
        }
    }
}
