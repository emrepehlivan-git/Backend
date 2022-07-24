using Application.DTOs.Category;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Categories.GetsingleCategory
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, ServiceResponse<CategoryResponseDTO>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;
        public GetSingleCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CategoryResponseDTO>> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            Category data = await _categoryReadRepository.GetByIdAsync(request.Id.ToString());
            CategoryResponseDTO dto = _mapper.Map<CategoryResponseDTO>(data);
            var response = new ServiceResponse<CategoryResponseDTO>(dto, true);
            return await Task.FromResult(response);
        }
    }
}