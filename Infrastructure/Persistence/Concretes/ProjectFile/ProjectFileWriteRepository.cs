using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Concretes
{
     public class ProjectFileWriteRepository : WriteRepository<ProjectFile>, IProjectFileWriteRepository
     {
          public ProjectFileWriteRepository(StoreDbContext context) : base(context)
          {
          }
     }
}
