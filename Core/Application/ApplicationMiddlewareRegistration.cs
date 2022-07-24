using Application.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Application
{
     public static class ApplicationMiddlewareRegistration
     {
          public static void UseApplicationMiddlewares (this WebApplication webApplication)
          {
               webApplication.UseMiddleware<ExceptionHandlerMiddleware>();
          }
     }
}
