using Application.DTOs.Category;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Categories.CreateCategory
{
     public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponseDTO>
     {
          readonly ICategoryWriteRepository _categoryWriteRepository;
          readonly ICategoryReadRepository _categoryReadRepository;
          readonly IMapper _mapper;

          public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
          {
               _categoryWriteRepository = categoryWriteRepository;
               _mapper = mapper;
               _categoryReadRepository = categoryReadRepository;
          }

          public async Task<CategoryResponseDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
          {
               var found = await _categoryReadRepository.GetSingleAsync(c => c.Name == request.Name);

               if (found != null)
                    throw new Exception("There is a category with this name");
               else
               {
                    Category category = _mapper.Map<Category>(request);
                    var data = await _categoryWriteRepository.AddAsync(category);
                    await _categoryWriteRepository.SaveAsync();
                    CategoryResponseDTO response = _mapper.Map<CategoryResponseDTO>(category);
                    return response;
               }
          }
     }
}
