using Application.Abstractions.Services;
using Application.Repositories;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concretes;
using Persistence.Configurations;
using Persistence.Contexts;
using Persistence.Services;

namespace Persistence
{
     public static class ServiceRegistration
     {
          public static void AddPersistenceServices(this IServiceCollection services)
          {
               services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(GetConnStrings.ConnectionStrings));
               services.AddIdentity<AppUser, AppRole>(opt =>
               {
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.User.RequireUniqueEmail = true;
               }).AddEntityFrameworkStores<StoreDbContext>();

               services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
               services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
               services.AddScoped<IProductReadRepository, ProductReadRepository>();
               services.AddScoped<IProductWriteRespository, ProductWriteRepository>();
               services.AddScoped<IAddressReadRepository, AddressReadRepository>();
               services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();
               services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
               services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
               services.AddScoped<IOrderReadRepository, OrderReadRepository>();
               services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
               services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
               services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
               services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
               services.AddScoped<IProductImageFileWriteRespository, ProductImageFileWriteRepository>();
               services.AddScoped<IProjectFileReadRepository, ProjectFileReadRepository>();
               services.AddScoped<IProjectFileWriteRepository, ProjectFileWriteRepository>();
               services.AddScoped<IUserService, UserService>();
               services.AddScoped<IInternalService, AuthService>();
               services.AddScoped<IExternalService, AuthService>();
               services.AddScoped<IAuthService, AuthService>();
          }
     }
}
