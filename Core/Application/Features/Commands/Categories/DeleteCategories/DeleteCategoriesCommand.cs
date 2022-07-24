using MediatR;

namespace Application.Features.Commands.Categories.DeleteCategories
{
     public class DeleteCategoriesCommand : IRequest<bool>
     {
          public List<Guid> Ids { get; set; }

          public DeleteCategoriesCommand (List<Guid> ıds)
          {
               Ids = ıds;
          }
     }
}
