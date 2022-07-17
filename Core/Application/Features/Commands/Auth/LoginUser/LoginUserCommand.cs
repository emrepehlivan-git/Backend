using Application.DTOs.Auth;
using MediatR;

namespace Application.Features.Commands.AppUsers.LoginUser
{
     public class LoginUserCommand : IRequest<Token>
     {
          public string Email { get; set; }
          public string Password { get; set; }
     }
}
