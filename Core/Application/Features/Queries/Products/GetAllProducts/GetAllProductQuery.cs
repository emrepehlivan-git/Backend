using Application.DTOs.Product;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Queries.Products.GetAllProducts
{
     public class GetAllProductQuery : IRequest<ServiceResponse<List<ProductsResponseDTO>>>
     {
          public int Page { get; set; } = 0;
          public int PageSize { get; set; } = 5;
     }
}
