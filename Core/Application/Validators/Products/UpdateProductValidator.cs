using Application.Features.Commands.Products.UpdateProduct;
using FluentValidation;

namespace Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Description).MinimumLength(3);
            RuleFor(x => x.Price).Must(s => s >= 0).When(x => x.Price != null);
            RuleFor(x => x.Stock).Null().Must(s => s >= 0).When(x => x.Stock != null);
        }
    }
}
