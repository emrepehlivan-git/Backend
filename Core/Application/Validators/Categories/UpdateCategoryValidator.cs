using Application.Features.Commands.Categories.UpdateCategory;
using FluentValidation;

namespace Application.Validators.Categories
{
     public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
     {
          public UpdateCategoryValidator()
          {
               RuleFor(c => c.Name)
                    .MinimumLength(3)
                    .NotNull()
                    .NotEmpty();
               RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull();
          }
     }
}
