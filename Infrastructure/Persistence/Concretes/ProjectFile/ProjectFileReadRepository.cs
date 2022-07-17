using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class ProjectFileReadRepository : ReadRepository<ProjectFile>, IProjectFileReadRepository
     {
          public ProjectFileReadRepository(StoreDbContext context) : base(context)
          {
          }
     }
}
