using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
     {
          public InvoiceFileWriteRepository(StoreDbContext context) : base(context)
          {
          }
     }
}
