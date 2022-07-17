using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class AddressReadRepository : ReadRepository<Address>, IAddressReadRepository
    {
        public AddressReadRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
