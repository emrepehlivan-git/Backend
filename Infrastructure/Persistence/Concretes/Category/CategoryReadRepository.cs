using Domain.Entities;
using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
