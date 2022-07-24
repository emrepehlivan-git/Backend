using Application.DTOs.Category;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Categories.CreateCategories
{
     public class CreateCategoriesCommandHandler : IRequestHandler<CreateCategoriesCommand, ServiceResponse<List<CategoryResponseDTO>>>
     {
          readonly ICategoryWriteRepository _categoryWriteRepository;
          readonly ICategoryReadRepository _categoryReadRepository;
          readonly IMapper _mapper;
          public CreateCategoriesCommandHandler (ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository, IMapper mapper)
          {
               _categoryWriteRepository = categoryWriteRepository;
               _categoryReadRepository = categoryReadRepository;
               _mapper = mapper;
          }

          public async Task<ServiceResponse<List<CategoryResponseDTO>>> Handle (CreateCategoriesCommand request, CancellationToken cancellationToken)
          {
               foreach (var c in request.categories)
               {
                    var found = await _categoryReadRepository.GetSingleAsync(x => x.Name == c.Name);
                    if (found is not null)
                         throw new Exception($"{found.Name} exists");
               }

               var dto = _mapper.Map<List<Category>>(request.categories);
               await _categoryWriteRepository.AddRangeAsync(dto);
               await _categoryWriteRepository.SaveAsync();
               var response = _mapper.Map<List<CategoryResponseDTO>>(dto);
               return new ServiceResponse<List<CategoryResponseDTO>>(response, true);
          }
     }
}
