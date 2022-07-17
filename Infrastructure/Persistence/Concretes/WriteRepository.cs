using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
     {
          private readonly StoreDbContext _context;

          public WriteRepository(StoreDbContext context)
          {
               _context = context;
          }

          public DbSet<T> Table => _context.Set<T>();

          public async Task<bool> AddAsync(T entity)
          {
               EntityEntry<T> entityEntry = await Table.AddAsync(entity);
               return entityEntry.State == EntityState.Added;
          }

          public async Task<bool> AddRangeAsync(List<T> entities)
          {
               await Table.AddRangeAsync(entities);
               return true;
          }

          public bool Remove(T entity)
          {
               EntityEntry<T> entityEntry = Table.Remove(entity);
               return entityEntry.State == EntityState.Deleted;
          }

          public async Task<bool> RemoveAsync(string id)
          {
               T model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
               return Remove(model);
          }
          public bool RemoveRange(List<T> entities)
          {
               Table.RemoveRange(entities);
               return true;
          }

          public bool Update(T entity)
          {
               EntityEntry entityEntry = Table.Update(entity);
               return entityEntry.State == EntityState.Modified;
          }

          public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
     }
}
