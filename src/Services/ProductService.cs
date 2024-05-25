using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
namespace sda_onsite_2_csharp_backend_teamwork.src.services;

public class ProductService : IProductService
{
    private IProductRepository _ProductRepository;
    private IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _ProductRepository = productRepository;
        _mapper = mapper;
    }
    public IEnumerable<ProductWithStock> FindAll(int limit, int offset)
    {
        IEnumerable<ProductWithStock> products = _ProductRepository.FindAll(limit, offset);
        // return products.Select(_mapper.Map<ProductDTO>);
        return products;
    }
    public ProductDTO? FindeOne(Guid Id)
    {
        var findProduct = _ProductRepository.FindeOne(Id);
        return _mapper.Map<ProductDTO>(findProduct);


    }
    public ProductDTO CreateOne(ProductReadDTO product)
    {
        Product creatProduct = _mapper.Map<Product>(product);
        return _mapper.Map<ProductDTO>(_ProductRepository.CreateOne(creatProduct));
    }

    public List<ProductReadDTO> Search(string keyword)
    {
        // Assuming _context is your DbContext and Products is your DbSet<Product>
        var foundProducts = _ProductRepository.Search(keyword)
        .Where(p => p.Name.Contains(keyword))
        .Select(p => new ProductReadDTO
        {
            // Map your Product entity to ProductReadDto

            CategoryId = p.CategoryId,
            Name = p.Name,
            Description = p.Description,

            // Map other properties as needed
        })
        .ToList();
        return foundProducts;
    }

    public bool DeleteProduct(Guid id)
    {
        Product? product = _ProductRepository.FindeOne(id);
        if (product is not null)
        {
            _ProductRepository.DeleteProduct(product);
            return true;
        }
        return false;
    }

    public ProductReadDTO UpdateOne(Guid productId, ProductUpdateDTO updatedProduct)
    {
        var product = _ProductRepository.FindeOne(productId);
        //ToDo: implement if  statement for each property in product to check if it exists before updating
        if (product != null)
        {
            Console.WriteLine($"product is found and update in service file");

            product.Name = updatedProduct.Name;
            product.CategoryId = updatedProduct.CategoryId;
            product.Image = updatedProduct.Image;
            product.Description = updatedProduct.Description;
            _ProductRepository.UpdateOne(product);

            return _mapper.Map<ProductReadDTO>(product);
        }

        return _mapper.Map<ProductReadDTO>(product);

    }
}
