using Application.Features.Commands.Products.UpdateProduct;
using FluentValidation;

namespace Application.Validators.Products
{
     public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
     {
          public UpdateProductValidator()
          {
               RuleFor(x => x.Id).NotEmpty().NotNull();
               RuleFor(x => x.Name).NotEmpty().NotNull();
               RuleFor(x => x.Description).NotEmpty().NotNull();
               RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(0);
               RuleFor(x => x.Stock).NotEmpty().NotNull().Must(s => s >= 0);
          }
     }
}
