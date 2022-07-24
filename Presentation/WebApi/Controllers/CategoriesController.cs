using Application.DTOs.Category;
using Application.Features.Commands.Categories.CreateCategories;
using Application.Features.Commands.Categories.CreateCategory;
using Application.Features.Commands.Categories.DeleteCategories;
using Application.Features.Commands.Categories.DeleteCategory;
using Application.Features.Commands.Categories.UpdateCategory;
using Application.Features.Queries.Categories;
using Application.Features.Queries.Categories.GetAllCategories;
using Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CategoriesController : ControllerBase
     {
          readonly IMediator _mediator;

          public CategoriesController (IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll ([FromQuery] Pagination pagination)
          {
               var query = new GetAllCategoriesQuery(){Pagination = pagination};
               var response = await _mediator.Send(query);
               return Ok(response);
          }

          [HttpGet("{id}")]
          public async Task<IActionResult> GetSingle (Guid id)
          {
               var res = await _mediator.Send(new GetSingleCategoryQuery { Id = id });
               return Ok(res);
          }

          [HttpPost]
          public async Task<IActionResult> AddCategory (CreateCategoryCommand command)
          {
               var res = await _mediator.Send(command);
               return Ok(res);
          }

          [HttpPost("addcategories")]
          public async Task<IActionResult> AddCategories ([FromBody] List<CategoryRequestDTO> categories)
          {
               var res = await _mediator.Send(new CreateCategoriesCommand(categories));
               return Ok(res);
          }

          [HttpPut]
          public async Task<IActionResult> UpdateCategory (UpdateCategoryCommand command)
          {
               var res = await _mediator.Send(command);
               return Ok(res);
          }

          [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCategory ([FromRoute] string id)
          {
               await _mediator.Send(new DeleteCategoryCommand(id));
               return NoContent();
          }

          [HttpDelete]
          public async Task<IActionResult> DeleteCategories ([FromBody] DeleteCategoriesDTO ids)
          {
               await _mediator.Send(new DeleteCategoriesCommand(ids.Ids));
               return NoContent();
          }
     }
}
