using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands.Products.DeleteProduct
{
     public class DeleteProductCommand : IRequest<ServiceResponse<bool>>
     {
          public string Id { get; set; }

          public DeleteProductCommand (string ıd)
          {
               Id = ıd;
          }
     }
}
