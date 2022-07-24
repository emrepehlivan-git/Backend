using Application.DTOs.Category;
using Application.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<CategoryResponseDTO>>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<ServiceResponse<CategoryResponseDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var found = await _categoryReadRepository.ExistsAsync(c => c.Name == request.Name);
            if (found == false)
                throw new Exception("This Category exists");

            Category data = _mapper.Map<Category>(request);
            _categoryWriteRepository.Update(data);
            await _categoryWriteRepository.SaveAsync();
            CategoryResponseDTO response = _mapper.Map<CategoryResponseDTO>(data);
            return await Task.FromResult(new ServiceResponse<CategoryResponseDTO>(response, true));
        }
    }
}
