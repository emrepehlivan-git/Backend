using Application.DTOs.Category;
using Application.Features.Commands.Categories.CreateCategory;
using Application.Features.Commands.Categories.DeleteCategory;
using Application.Features.Commands.Categories.UpdateCategory;
using Application.Features.Queries.Categories.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CategoriesController : ControllerBase
     {
          readonly IMediator _mediator;

          public CategoriesController(IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll([FromQuery] GetAllCategoriesQuery query)
          {
               List<CategoryResponseDTO> res = await _mediator.Send(query);
               return Ok(res);
          }

          [HttpPost]
          public async Task<IActionResult> AddCategory(CreateCategoryCommand command)
          {
               CategoryResponseDTO res = await _mediator.Send(command);
               return CreatedAtAction(nameof(GetAll), res);
          }

          [HttpPut]
          public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
          {
               CategoryResponseDTO res = await _mediator.Send(command);
               return Ok(res);
          }

          [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommand command)
          {
               await _mediator.Send(command);
               return NoContent();
          }
     }
}
