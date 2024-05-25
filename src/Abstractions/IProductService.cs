using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IProductService
{
    public IEnumerable<ProductWithStock> FindAll(int limit, int offset);
    public ProductDTO? FindeOne(Guid Id);
    public ProductDTO CreateOne(ProductReadDTO product);
    public List<ProductReadDTO> Search(string keyword);
    public bool DeleteProduct(Guid id);
    public ProductReadDTO UpdateOne(Guid productId, ProductUpdateDTO updatedProduct);
}
