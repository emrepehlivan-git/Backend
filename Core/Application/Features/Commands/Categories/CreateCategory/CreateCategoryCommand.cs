using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Commands.Categories.CreateCategory
{
     public class CreateCategoryCommand : IRequest<CategoryResponseDTO>
     {
          public string Name { get; set; }
     }
}
