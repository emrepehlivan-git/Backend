using Application.DTOs.Category;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands.Categories.UpdateCategory
{
     public class UpdateCategoryCommand : IRequest<ServiceResponse<CategoryResponseDTO>>
     {
          public string Id { get; set; }
          public string Name { get; set; }
     }
}
