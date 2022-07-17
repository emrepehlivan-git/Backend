using Application.Abstractions.Services;
using Application.DTOs.AppUser;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.AppUsers.UpdateUser
{
     public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponseDTO>
     {
          readonly IUserService _userService;
          readonly IMapper _mapper;

          public UpdateUserCommandHandler(IMapper mapper, IUserService userService)
          {
               _mapper = mapper;
               _userService = userService;
          }

          public async Task<UserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
          {
               UpdateUserRequestDTO dto = _mapper.Map<UpdateUserRequestDTO>(request);
               UserResponseDTO response = await _userService.UpdateAsync(dto);
               return response;
          }
     }
}
