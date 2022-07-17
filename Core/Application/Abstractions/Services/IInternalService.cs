namespace Application.Abstractions.Services
{
     public interface IInternalService
     {
          Task<Application.DTOs.Auth.Token> LoginAsync(string email, string password, int tokenLifeTime);
     }
}