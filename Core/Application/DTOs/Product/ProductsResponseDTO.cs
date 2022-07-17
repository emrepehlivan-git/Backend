namespace Application.DTOs.Product
{
     public class ProductsResponseDTO
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public float Price { get; set; }
          public int Stock { get; set; }
          public string CategoryName { get; set; }
     }
}
