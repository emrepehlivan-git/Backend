using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
    public class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(StoreDbContext context) : base(context)
        {
        }
    }
}
