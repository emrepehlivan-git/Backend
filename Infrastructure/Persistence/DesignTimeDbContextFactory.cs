using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence.Configurations;
using Persistence.Contexts;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<StoreDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(GetConnStrings.ConnectionStrings);
            return new (dbContextOptionsBuilder.Options);
        }
    }
}
