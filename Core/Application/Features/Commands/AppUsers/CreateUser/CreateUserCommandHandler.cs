using Application.Abstractions.Services;
using Application.DTOs.AppUser;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.AppUsers.CreateUser
{
     public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse<UserResponseDTO>>
     {
          readonly IUserService _userService;
          readonly IMapper _mapper;

          public CreateUserCommandHandler(IUserService userService, IMapper mapper)
          {
               _userService = userService;
               _mapper = mapper;
          }

          public async Task<ServiceResponse<UserResponseDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
          {
               CreateUserRequestDTO data = _mapper.Map<CreateUserRequestDTO>(request);
               UserResponseDTO result = await _userService.CreateAsync(data);
               var response = new ServiceResponse<UserResponseDTO>(result, true);
               return await Task.FromResult(response);
          }
     }
}
