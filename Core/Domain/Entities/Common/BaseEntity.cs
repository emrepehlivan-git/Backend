

namespace Domain.Entities.Common
{
     public class BaseEntity
     {
          public virtual Guid Id { get; set; }
          public virtual DateTime CreatedDate { get; set; }
          public virtual DateTime UpdatedDate { get; set; }

     }
}
