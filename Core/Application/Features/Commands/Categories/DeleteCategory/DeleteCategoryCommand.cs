using MediatR;

namespace Application.Features.Commands.Categories.DeleteCategory
{
     public class DeleteCategoryCommand : IRequest<bool>
     {
          public string Id { get; set; }

          public DeleteCategoryCommand (string ıd)
          {
               Id = ıd;
          }
     }
}
