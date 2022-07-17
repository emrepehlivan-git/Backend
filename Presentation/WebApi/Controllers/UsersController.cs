using Application.DTOs.AppUser;
using Application.Features.Commands.AppUsers.CreateUser;
using Application.Features.Commands.AppUsers.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [Route("api/[controller]/[action]")]
     [ApiController]
     public class UsersController : ControllerBase
     {
          readonly IMediator _mediator;

          public UsersController(IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpPost]
          public async Task<IActionResult> Create(CreateUserCommand command)
          {
               UserResponseDTO res = await _mediator.Send(command);
               return Ok(res);
          }

          [HttpPut]
          public async Task<IActionResult> Update(UpdateUserCommand command)
          {
               UserResponseDTO res = await _mediator.Send(command);
               return Ok(res);
          }
     }
}