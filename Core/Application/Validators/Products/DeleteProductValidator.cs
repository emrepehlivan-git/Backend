using Application.Features.Commands.Products.DeleteProduct;
using FluentValidation;

namespace Application.Validators.Products
{
     public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
     {
          public DeleteProductValidator()
          {
               RuleFor(c => c.Id)
                    .NotEmpty()
                    .NotNull();
          }
     }
}
