using Application.DTOs.Category;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ServiceResponse<List<CategoryResponseDTO>>>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CategoryResponseDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var Count = await _categoryReadRepository.CountAsync();
            List<Category> data = _categoryReadRepository.GetAll().Skip(request.Pagination.Page * request.Pagination.PageSize).Take(request.Pagination.PageSize).ToList();
            List<CategoryResponseDTO> dto = _mapper.Map<List<CategoryResponseDTO>>(data);
            var response = new PagedResponse<List<CategoryResponseDTO>>(dto, request.Pagination.Page, request.Pagination.PageSize, Count, true);
            return await Task.FromResult(response);
        }
    }
}
