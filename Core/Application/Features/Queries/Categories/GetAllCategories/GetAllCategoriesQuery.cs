using Application.DTOs.Category;
using Application.RequestParameters;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Queries.Categories.GetAllCategories
{
     public class GetAllCategoriesQuery : IRequest<ServiceResponse<List<CategoryResponseDTO>>>
     {
          public Pagination Pagination { get; set; }
     }
}
