using Application.DTOs.Category;
using FluentValidation;

namespace Application.Validators.Categories
{
     public class CreateCategoriesValidator : AbstractValidator<CategoryRequestDTO>
     {
          public CreateCategoriesValidator ( )
          {
               RuleFor(c => c.Name)
                    .NotEmpty()
                    .NotNull();
          }
     }
}
