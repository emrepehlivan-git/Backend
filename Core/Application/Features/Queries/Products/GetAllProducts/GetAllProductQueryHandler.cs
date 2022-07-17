using Application.DTOs.Product;
using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Products.GetAllProducts
{
     public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductsResponseDTO>>
     {
          private readonly IProductReadRepository _productReadRepository;
          private readonly IMapper _mapper;

          public GetAllProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
          {
               _productReadRepository = productReadRepository;
               _mapper = mapper;
          }

          public async Task<List<ProductsResponseDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
          {
               var data = _productReadRepository.GetAll().Include(x => x.Category).Skip(request.Page * request.PageSize).Take(request.PageSize).ToList();
               List<ProductsResponseDTO> dto = _mapper.Map<List<ProductsResponseDTO>>(data);

               return await Task.FromResult(dto);
          }
     }
}
