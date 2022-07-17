using Application.DTOs.AppUser;
using MediatR;

namespace Application.Features.Commands.AppUsers.UpdateUser
{
     public class UpdateUserCommand : IRequest<UserResponseDTO>
     {
          public string FullName { get; set; }
          public string UserName { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
     }
}
