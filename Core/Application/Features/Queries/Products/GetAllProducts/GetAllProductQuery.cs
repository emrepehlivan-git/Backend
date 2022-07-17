using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Queries.Products.GetAllProducts
{
     public class GetAllProductQuery : IRequest<List<ProductsResponseDTO>>
     {
          // public Pagination Pagination { get; set; }
          public int Page { get; set; } = 0;
          public int PageSize { get; set; } = 5;
     }
}
