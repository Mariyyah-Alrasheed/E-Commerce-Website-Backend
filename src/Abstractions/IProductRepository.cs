using sda_onsite_2_csharp_backend_teamwork.src.DTOs;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IProductRepository
{
  public IEnumerable<ProductWithStock> FindAll(int limit, int offset);

  public Product? FindeOne(Guid Id);
  public Product CreateOne(Product product);
  public List<Product> Search(string keyword);
  public void DeleteProduct(Product product);
  public Product UpdateOne(Product UpdateProduct);

}
