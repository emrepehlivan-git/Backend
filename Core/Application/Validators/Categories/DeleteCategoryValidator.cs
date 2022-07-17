using Application.Features.Commands.Categories.DeleteCategory;
using FluentValidation;

namespace Application.Validators.Categories
{
     public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
     {
          public DeleteCategoryValidator()
          {
               RuleFor(x => x.Id)
                    .NotNull()
                    .NotEmpty();
          }
     }
}
