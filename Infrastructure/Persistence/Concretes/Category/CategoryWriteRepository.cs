using Domain.Entities;
using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
