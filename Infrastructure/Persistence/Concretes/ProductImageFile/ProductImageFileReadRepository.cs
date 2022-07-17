using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
     {
          public ProductImageFileReadRepository(StoreDbContext context) : base(context)
          {
          }
     }
}
