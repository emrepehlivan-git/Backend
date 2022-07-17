using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
     {
          public InvoiceFileReadRepository(StoreDbContext context) : base(context)
          {
          }
     }
}
