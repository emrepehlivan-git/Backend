using Application.DTOs.Category;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands.Categories.CreateCategories
{
     public class CreateCategoriesCommand : IRequest<ServiceResponse<List<CategoryResponseDTO>>>
     {
          public List<CategoryRequestDTO> categories { get; set; }

          public CreateCategoriesCommand (List<CategoryRequestDTO> categories)
          {
               this.categories = categories;
          }
     }
}
