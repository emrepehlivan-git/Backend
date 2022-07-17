using Application.DTOs.AppUser;
using Application.DTOs.Auth;
using Application.Features.Commands.AppUsers.CreateUser;
using Application.Features.Commands.AppUsers.UpdateUser;
using AutoMapper;
using Domain.Entities.Identity;

namespace Application.Mappings
{
     public class UserProfile : Profile
     {
          public UserProfile()
          {
               CreateMap<AppUser, CreateUserRequestDTO>().ReverseMap();
               CreateMap<AppUser, UpdateUserRequestDTO>().ReverseMap();
               CreateMap<CreateUserCommand, CreateUserRequestDTO>().ReverseMap();
               CreateMap<UpdateUserCommand, UpdateUserRequestDTO>().ReverseMap();
               CreateMap<Token, UserResponseDTO>().ReverseMap();
          }
     }
}
