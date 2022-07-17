using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class OrderReadRepository : ReadRepository<Order>,IOrderReadRepository
    {
        public OrderReadRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
