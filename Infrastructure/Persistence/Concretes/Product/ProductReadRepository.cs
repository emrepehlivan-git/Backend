using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class ProductReadRepository : ReadRepository<Product>,IProductReadRepository
    {
        public ProductReadRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
