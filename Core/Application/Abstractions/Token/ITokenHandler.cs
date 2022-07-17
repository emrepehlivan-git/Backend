namespace Application.Abstractions.Token
{
     public interface ITokenHandler
     {
          DTOs.Auth.Token CreateAccessToken(int minute);
     }
}
