using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Order:BaseEntity
    {
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
