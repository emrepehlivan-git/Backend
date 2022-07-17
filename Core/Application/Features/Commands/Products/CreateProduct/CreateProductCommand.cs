﻿using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Commands.Products.CreateProduct
{
     public class CreateProductCommand : IRequest<ProductsResponseDTO>
     {
          public string Name { get; set; }
          public string Description { get; set; }
          public float Price { get; set; }
          public int Stock { get; set; }
          public string CategoryId { get; set; }
     }
}
