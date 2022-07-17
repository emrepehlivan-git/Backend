using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRespository
    {
        public ProductWriteRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
