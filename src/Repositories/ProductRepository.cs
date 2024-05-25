using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Repository;

public class ProductRepository : IProductRepository
{
    private DbSet<Product> _products;
    private DbSet<Stock> _stocks;
    private DatabaseContext _databaseContext;
    public ProductRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _products = _databaseContext.Product;
        _stocks = _databaseContext.Stock;
    }
    public IEnumerable<ProductWithStock> FindAll(int limit, int offset)
    {
        var productWithStock = from product in _products
                               join stock in _stocks
                               on product.Id equals stock.ProductId
                               into productStocks
                               from stock in productStocks.DefaultIfEmpty()
                               select new ProductWithStock
                               {
                                   Id = product.Id,
                                   CategoryId = product.CategoryId,
                                   StockId = stock != null ? stock.Id : null,
                                   Color = stock != null ? stock.Color : null,
                                   Size = stock != null ? stock.Size : null,
                                   Price = stock != null ? stock.Price : null,
                                   Description = product.Description,
                                   Image = product.Image,
                                   Name = product.Name,
                                   Quantity = stock != null ? stock.StockQuantity : (int?)null
                               };

        if (limit == 0 && offset == 0)
        {
            return productWithStock;
        }



        return productWithStock.Skip(offset).Take(limit);
    }

    public Product? FindeOne(Guid Id)
    {
        Product? product = _products.FirstOrDefault(product => product.Id == Id);
        if (product != null)
        {
            return product;
        }
        return null;
    }
    public Product CreateOne(Product product)
    {
        _products.Add(product);
        _databaseContext.SaveChanges();
        return product;
    }
    public List<Product> Search(string keyword)
    {
        return _products
                .Where(p => p.Name.Contains(keyword))
                .ToList();
    }
    public Product UpdateOne(Product UpdateProduct)
    {
        _products.Update(UpdateProduct);
        _databaseContext.SaveChanges();

        return UpdateProduct;
    }
    public void DeleteProduct(Product product)
    {
        _products.Remove(product);
        _databaseContext.SaveChanges();
    }

}
