using Application.Features.Commands.Products.CreateProduct;
using FluentValidation;

namespace Application.Validators.Products
{
     public class CreateProductValidator : AbstractValidator<CreateProductCommand>
     {
          public CreateProductValidator()
          {
               RuleFor(x => x.Name).NotEmpty().NotNull();
               RuleFor(x => x.Description).NotEmpty().NotNull();
               RuleFor(x => x.Price).NotEmpty().NotNull().GreaterThan(0);
               RuleFor(x => x.Stock).NotEmpty().NotNull().Must(s => s >= 0);
          }
     }
}
