using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Commands.Categories.UpdateCategory
{
     public class UpdateCategoryCommand : IRequest<CategoryResponseDTO>
     {
          public string Id { get; set; }
          public string Name { get; set; }
     }
}
