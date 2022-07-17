using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRespository
     {
          public ProductImageFileWriteRepository(StoreDbContext context) : base(context)
          {
          }
     }
}
