using Application.Repositories;
using MediatR;

namespace Application.Features.Commands.Products.DeleteProduct
{
     public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
     {
          readonly IProductWriteRespository _productWriteRepository;
          readonly IProductReadRepository _productReadRepository;

          public DeleteProductCommandHandler(IProductWriteRespository productWriteRepository, IProductReadRepository productReadRepository)
          {
               _productWriteRepository = productWriteRepository;
               _productReadRepository = productReadRepository;
          }

          public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
          {
               var result = await _productReadRepository.GetByIdAsync(request.Id);
               if (result is not null)
               {
                    await _productWriteRepository.RemoveAsync(request.Id);
                    await _productWriteRepository.SaveAsync();
                    return true;
               }
               else
                    throw new Exception("Product not found!");
          }
     }
}
