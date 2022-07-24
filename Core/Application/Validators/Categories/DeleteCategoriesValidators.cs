using Application.DTOs.Category;
using FluentValidation;

namespace Application.Validators.Categories
{
     public class DeleteCategoriesValidators : AbstractValidator<DeleteCategoriesDTO>
     {
          public DeleteCategoriesValidators ( )
          {
               RuleFor(x => x.Ids).NotEmpty();
          }
     }
}