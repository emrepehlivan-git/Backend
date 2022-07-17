using Application.Abstractions.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastructure.Services.Token
{
     public class TokenHandler : ITokenHandler
     {
          readonly IConfiguration _configuration;

          public TokenHandler(IConfiguration configuration)
          {
               _configuration = configuration;
          }

          public Application.DTOs.Auth.Token CreateAccessToken(int minute)
          {
               Application.DTOs.Auth.Token token = new();

               SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

               SigningCredentials signingCredentials = new(key, SecurityAlgorithms.HmacSha256);

               token.Expiration = DateTime.UtcNow.AddMinutes(minute);
               JwtSecurityToken jwtSecurityToken = new(
                    audience: _configuration["Token:Audience"],
                    issuer: _configuration["Token:Issuer"],
                    expires: token.Expiration,
                    notBefore: DateTime.UtcNow,
                    signingCredentials: signingCredentials
                    );

               JwtSecurityTokenHandler tokenHandler = new();
               token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

               return token;
          }
     }
}
