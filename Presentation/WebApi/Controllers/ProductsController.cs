using Application.DTOs.Product;
using Application.Features.Commands.Products.CreateProduct;
using Application.Features.Commands.Products.DeleteProduct;
using Application.Features.Commands.Products.UpdateProduct;
using Application.Features.Queries.Products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [Route("api/[controller]/[action]")]
     [ApiController]
     [Produces("application/json")]
     public class ProductsController : ControllerBase
     {
          readonly IMediator _mediator;

          public ProductsController(IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpGet]
          public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuery query)
          {
               List<ProductsResponseDTO> res = await _mediator.Send(query);
               return Ok(res);
          }

          [HttpPost]
          public async Task<IActionResult> AddProduct(CreateProductCommand command)
          {
               ProductsResponseDTO res = await _mediator.Send(command);
               return Ok(res);
          }

          [HttpPut]
          public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
          {
               UpdateProductResponseDTO res = await _mediator.Send(command);
               return Ok(res);
          }

          [HttpDelete("{Id}")]
          public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand command)
          {
               await _mediator.Send(command);
               return Ok();
          }
     }
}
