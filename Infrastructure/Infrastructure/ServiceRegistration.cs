using Application.Abstractions.Storage;
using Application.Abstractions.Token;
using Infrastructure.Enums;
using Infrastructure.Services.Storage;
using Infrastructure.Services.Storage.Local;
using Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
     public static class ServiceRegistration
     {

          public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
          {
               serviceCollection.AddScoped<IStorageService, StorageService>();
               serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
          }
          public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
          {
               serviceCollection.AddScoped<IStorage, T>();
          }
          public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
          {
               switch (storageType)
               {
                    case StorageType.Local:
                         serviceCollection.AddScoped<IStorage, LocalStorage>();
                         break;
                    default:
                         serviceCollection.AddScoped<IStorage, LocalStorage>();
                         break;
               }
          }
     }
}
