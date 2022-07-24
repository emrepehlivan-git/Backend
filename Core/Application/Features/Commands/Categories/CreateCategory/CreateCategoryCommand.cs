using Application.DTOs.Category;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands.Categories.CreateCategory
{
     public class CreateCategoryCommand : IRequest<ServiceResponse<CategoryResponseDTO>>
     {
          public string Name { get; set; }
     }
}
