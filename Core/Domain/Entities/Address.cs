using Domain.Entities.Common;

namespace Domain.Entities
{
     public class Address : BaseEntity
     {
          public string? City { get; set; }
          public string? Street { get; set; }
          public string? District { get; set; }
          public string? PostalCode { get; set; }
          public string? Region { get; set; }
     }
}
