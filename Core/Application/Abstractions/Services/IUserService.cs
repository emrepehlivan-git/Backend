using Application.DTOs.AppUser;

namespace Application.Abstractions.Services
{
     public interface IUserService
     {
          Task<UserResponseDTO> CreateAsync(CreateUserRequestDTO user);
          Task<UserResponseDTO> UpdateAsync(UpdateUserRequestDTO user);
     }
}