using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers;


public class ProductController : BaseController
{
    private IProductService _productSarvice;
    public ProductController(IProductService productSarvice)
    {
        _productSarvice = productSarvice;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductWithStock>> FindAll([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
    {
        return Ok(_productSarvice.FindAll(limit, offset));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ProductDTO> FindeOne(Guid id)
    {
        ProductDTO? findId = _productSarvice.FindeOne(id);

        if (findId is null) return NotFound();
        return Ok(findId);

    }
    [HttpPost]
    // [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductDTO> CreateOne([FromBody] ProductReadDTO newProduct)
    {
        if (newProduct is not null)
        {
            var product = _productSarvice.CreateOne(newProduct);
            return CreatedAtAction(nameof(CreateOne), product);
        }
        return BadRequest();
    }
    [HttpGet("search")] //Action method for searching products by keyword
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<ProductReadDTO>> Search(string keyword)
    {
        List<ProductReadDTO> foundProducts = _productSarvice.Search(keyword);
        if (foundProducts.Count == 0)
            return NotFound();

        return Ok(foundProducts);
    }

    [HttpDelete("{productId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]// documentation error status code
    public ActionResult<Product?> DeleteOne(Guid productId)
    {
        var deletedProduct = _productSarvice.DeleteProduct(productId);
        if (deletedProduct == false)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPatch("{productId}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductReadDTO> UpdateOne(Guid productId, [FromBody] ProductUpdateDTO updateProduct)
    {

        Console.WriteLine($"Update a product");

        var foundProduct = FindeOne(productId);

        if (foundProduct != null)
        {
            Console.WriteLine($"product is found in controller");
            ProductReadDTO product = _productSarvice.UpdateOne(productId, updateProduct);

            return Accepted(product);
        }
        Console.WriteLine($"product is not found in controller");
        return NotFound();
    }

}
