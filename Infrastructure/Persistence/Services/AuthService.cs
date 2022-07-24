using Application.Abstractions.Services;
using Application.Abstractions.Token;
using Application.DTOs.Auth;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Persistence.Exceptions;

namespace Persistence.Services
{
     public class AuthService : IAuthService
     {
          readonly ITokenHandler _tokenHandler;
          readonly UserManager<AppUser> _userManager;
          readonly SignInManager<AppUser> _signInManager;

          public AuthService (ITokenHandler tokenHandler, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
          {
               _tokenHandler = tokenHandler;
               _userManager = userManager;
               _signInManager = signInManager;
          }

          public async Task<Token> LoginAsync (string email, string password, int tokenLifeTime)
          {
               AppUser user = await _userManager.FindByEmailAsync(email);

               if (user is null)
                    throw new AuthException("User not found");

               SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

               if (!result.Succeeded)
                    throw new AuthException("Email or Password is incorrect");

               Token token = _tokenHandler.CreateAccessToken(tokenLifeTime);


               return token;
          }
     }
}
