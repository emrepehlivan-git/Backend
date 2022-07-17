using Application.DTOs.Category;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Categories.GetAllCategories
{
     public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponseDTO>>
     {
          readonly ICategoryReadRepository _categoryReadRepository;
          readonly IMapper _mapper;
          public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
          {
               _categoryReadRepository = categoryReadRepository;
               _mapper = mapper;
          }

          public async Task<List<CategoryResponseDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
          {
               List<Category> data = _categoryReadRepository.GetAll().ToList();
               List<CategoryResponseDTO> response = _mapper.Map<List<CategoryResponseDTO>>(data);
               return await Task.FromResult(response);
          }
     }
}
