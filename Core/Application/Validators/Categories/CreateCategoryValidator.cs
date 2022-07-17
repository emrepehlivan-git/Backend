using Application.Features.Commands.Categories.CreateCategory;
using FluentValidation;

namespace Application.Validators.Categories
{
     public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
     {
          public CreateCategoryValidator()
          {
               RuleFor(x => x.Name)
                    .MinimumLength(3)
                    .NotNull()
                    .NotEmpty();
          }
     }
}
