using Application.DTOs.Product;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ServiceResponse<ProductsResponseDTO>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? Stock { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
