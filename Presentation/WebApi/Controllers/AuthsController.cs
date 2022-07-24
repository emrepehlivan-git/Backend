using Application.Features.Commands.AppUsers.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
     [Route("api/[controller]/[action]")]
     [ApiController]
     public class AuthsController : ControllerBase
     {
          readonly IMediator _mediator;

          public AuthsController (IMediator mediator)
          {
               _mediator = mediator;
          }

          [HttpPost]
          public async Task<IActionResult> Login (LoginUserCommand command)
          {
               var res = await _mediator.Send(command);
               return Ok(res);
          }
     }
}
