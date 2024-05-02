using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DataBase;

namespace sda_onsite_2_csharp_backend_teamwork.src.Repository
{
    public class ProductRepository : IProductRepository
    {

        private DbSet<Product> _products;
        private DatabaseContext _databaseContext;
        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _products = _databaseContext.Product;

        }


        public IEnumerable<Product> FindAll()
        {
            return _products;
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


    }
}