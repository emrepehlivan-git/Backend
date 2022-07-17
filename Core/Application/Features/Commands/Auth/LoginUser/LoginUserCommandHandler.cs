using Application.Abstractions.Services;
using Application.DTOs.Auth;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.AppUsers.LoginUser
{
     public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Token>
     {
          readonly IAuthService _authService;

          public LoginUserCommandHandler(IAuthService authService, IMapper mapper)
          {
               _authService = authService;
          }

          public async Task<Token> Handle(LoginUserCommand request, CancellationToken cancellationToken)
          {
               Token response = await _authService.LoginAsync(request.Email, request.Password, 15);

               return response;
          }
     }
}
