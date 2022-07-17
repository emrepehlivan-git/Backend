using Application.Repositories;
using MediatR;

namespace Application.Features.Commands.Categories.DeleteCategory
{
     public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
     {
          readonly ICategoryWriteRepository _categoryWriteRepository;
          readonly ICategoryReadRepository _categoryReadRepository;

          public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
          {
               _categoryWriteRepository = categoryWriteRepository;
               _categoryReadRepository = categoryReadRepository;
          }

          public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
          {
               var found = await _categoryReadRepository.GetByIdAsync(request.Id);
               if (found is null)
                    throw new Exception("Category not found!");
               await _categoryWriteRepository.RemoveAsync(request.Id);
               await _categoryWriteRepository.SaveAsync();
               return true;
          }
     }
}
