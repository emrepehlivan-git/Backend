using Domain.Entities;
using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
