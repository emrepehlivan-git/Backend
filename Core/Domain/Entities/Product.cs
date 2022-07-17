using Domain.Entities.Common;

namespace Domain.Entities
{
     public class Product : BaseEntity
     {
          public string? Name { get; set; }
          public string? Description { get; set; }
          public float Price { get; set; }
          public int Stock { get; set; }

          public Guid CategoryId { get; set; }
          public virtual Category Category { get; set; }
          public virtual ICollection<Order> Orders { get; set; }
     }
}
