using MediatR;

namespace Application.Features.Commands.Products.DeleteProduct
{
     public class DeleteProductCommand : IRequest<bool>
     {
          public string Id { get; set; }
     }
}
