using Application.DTOs.Auth;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands.AppUsers.LoginUser
{
     public class LoginUserCommand : IRequest<ServiceResponse<Token>>
     {
          public string Email { get; set; }
          public string Password { get; set; }
     }
}
