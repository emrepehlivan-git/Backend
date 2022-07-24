using Application.Abstractions.Services;
using Application.DTOs.AppUser;
using AutoMapper;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Persistence.Exceptions;

namespace Persistence.Services
{
     public class UserService : IUserService
     {
          readonly UserManager<AppUser> _userManager;
          readonly IMapper _mapper;

          public UserService (UserManager<AppUser> userManager, IMapper mapper)
          {
               _userManager = userManager;
               _mapper = mapper;
          }

          public async Task<UserResponseDTO> CreateAsync (CreateUserRequestDTO user)
          {
               IdentityResult result = await _userManager.CreateAsync(new()
               {
                    Id = Guid.NewGuid().ToString(),
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
               }, user.Password);

               if (result.Succeeded)
               {
                    return new() { Message = "User created!" };
               }
               else
               {
                    throw new UserException($"{result.Errors?.FirstOrDefault()?.Description}");
               }
          }

          public async Task<UserResponseDTO> UpdateAsync (UpdateUserRequestDTO user)
          {
               AppUser data = _mapper.Map<AppUser>(user);

               IdentityResult result = await _userManager.UpdateAsync(data);

               if (result.Succeeded)
               {
                    return new() { Message = "User updated!" };
               }
               else
               {
                    throw new UserException($"{result.Errors?.FirstOrDefault()?.Description}");
               }
          }
     }
}