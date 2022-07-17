using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Queries.Categories.GetAllCategories
{
     public class GetAllCategoriesQuery : IRequest<List<CategoryResponseDTO>>
     {
     }
}
