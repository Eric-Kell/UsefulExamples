using System.Collections.Generic;
using SportsStore.Domain.Entities;

/*
Using Repository-Pattern to encapsulate working with real data
*/

namespace SportsStore.Domain.Abstract
{
  public interface IProductRepository
  {
    IEnumerable<Product> Products { get; }
    void SaveProduct(Product product);
    Product DeleteProduct(int productID);
  }
}