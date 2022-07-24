using Application.Repositories;
using MediatR;

namespace Application.Features.Commands.Categories.DeleteCategories
{
     public class DeleteCategoriesCommandHandler : IRequestHandler<DeleteCategoriesCommand, bool>
     {
          readonly ICategoryWriteRepository _categoryWriteRepository;

          public DeleteCategoriesCommandHandler (ICategoryWriteRepository categoryWriteRepository)
          {
               _categoryWriteRepository = categoryWriteRepository;
          }

          public async Task<bool> Handle (DeleteCategoriesCommand request, CancellationToken cancellationToken)
          {
               foreach (var id in request.Ids)
               {
                    await _categoryWriteRepository.RemoveAsync(id.ToString());
               }
               await _categoryWriteRepository.SaveAsync();

               return true;
          }
     }
}
