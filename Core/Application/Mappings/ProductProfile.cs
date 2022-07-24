using Application.DTOs.Product;
using Application.Features.Commands.Products.CreateProduct;
using Application.Features.Commands.Products.UpdateProduct;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductsResponseDTO>()
                      .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.Name)
                      ).ReverseMap();

            CreateMap<Product, UpdateProductResponseDTO>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<Product, UpdateProductCommand>()
            .ForMember(dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryId)
            ).ReverseMap();
        }
    }
}
