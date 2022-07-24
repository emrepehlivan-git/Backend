using Application.Abstractions.Services;
using Application.DTOs.AppUser;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.AppUsers.UpdateUser
{
     public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceResponse<UserResponseDTO>>
     {
          readonly IUserService _userService;
          readonly IMapper _mapper;

          public UpdateUserCommandHandler(IMapper mapper, IUserService userService)
          {
               _mapper = mapper;
               _userService = userService;
          }

          public async Task<ServiceResponse<UserResponseDTO>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
          {
               UpdateUserRequestDTO dto = _mapper.Map<UpdateUserRequestDTO>(request);
               UserResponseDTO data = await _userService.UpdateAsync(dto);
               var response = new ServiceResponse<UserResponseDTO>(data, true);
               return await Task.FromResult(response);
          }
     }
}
