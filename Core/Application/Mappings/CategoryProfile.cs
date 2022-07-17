using Application.DTOs.Category;
using Application.Features.Commands.Categories.CreateCategory;
using Application.Features.Commands.Categories.UpdateCategory;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
     public class CategoryProfile : Profile
     {
          public CategoryProfile()
          {
               CreateMap<Category, CategoryResponseDTO>();
               CreateMap<Category, CreateCategoryCommand>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ReverseMap();
               CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
          }
     }
}
