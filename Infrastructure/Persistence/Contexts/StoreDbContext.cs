using Domain.Entities;
using Domain.Entities.Common;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
     public class StoreDbContext : IdentityDbContext<AppUser, AppRole, string>
     {
          public StoreDbContext(DbContextOptions<StoreDbContext> contextOptions) : base(contextOptions) { }

          public virtual DbSet<Product> Products { get; set; }
          public virtual DbSet<Order> Orders { get; set; }
          public virtual DbSet<Customer> Customers { get; set; }
          public virtual DbSet<Address> Addresses { get; set; }
          public virtual DbSet<Category> Categories { get; set; }
          public virtual DbSet<ProjectFile> ProjectFiles { get; set; }
          public virtual DbSet<InvoiceFile> InvoiceFiles { get; set; }
          public virtual DbSet<ProductImageFile> ProductImageFiles { get; set; }

          public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
          {
               var datas = ChangeTracker.Entries<BaseEntity>();

               foreach (var data in datas)
               {
                    _ = data.State switch
                    {
                         EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                         EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                         _ => DateTime.Now
                    };

               }
               return await base.SaveChangesAsync(cancellationToken);
          }
     }
}
