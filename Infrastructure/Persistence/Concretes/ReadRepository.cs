using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Concretes
{
     public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
     {
          private readonly StoreDbContext _context;

          public ReadRepository(StoreDbContext context)
          {
               _context = context;
          }

          public DbSet<T> Table => _context.Set<T>();

          public IQueryable<T> GetAll(bool tracking = true)
          {
               var query = Table.AsQueryable();
               if (!tracking)
                    query = query.AsNoTracking();
               return query;
          }

          public IQueryable<T> GetAll(Expression<Func<T, bool>> expression,bool tracking = true)
          {
               var query = Table.AsQueryable().Where(expression);
                    if (!tracking)
                         query = query.AsNoTracking();
                    return query;
          }

          public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
          {
               var query = Table.Where(expression);
               if (!tracking)
                    query = query.AsNoTracking();
               return query;
          }

          public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
          {
               var query = Table.AsQueryable();
               if (!tracking)
                    query = query.AsNoTracking();
               return await query.FirstOrDefaultAsync(expression);
          }

          public async Task<T> GetByIdAsync(string id, bool tracking = true)
          {
               var query = Table.AsQueryable();
               if (!tracking)
                    query = Table.AsNoTracking();
               return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
          }        
    }
}
