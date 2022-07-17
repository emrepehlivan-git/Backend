using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class OrderWriteRepository : WriteRepository<Order>,IOrderWriteRepository
    {
        public OrderWriteRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
