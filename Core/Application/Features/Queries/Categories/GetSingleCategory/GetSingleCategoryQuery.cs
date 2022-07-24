using Application.DTOs.Category;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Queries.Categories
{
    public class GetSingleCategoryQuery:IRequest<ServiceResponse<CategoryResponseDTO>>
    {
        public Guid Id { get; set; }
    }
}