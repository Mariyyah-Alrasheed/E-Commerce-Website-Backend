using System.ComponentModel.DataAnnotations;
namespace sda_onsite_2_csharp_backend_teamwork.src.DTOs;

public class ProductReadDTO
{
    public Guid CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Image { get; set; }

    public string Description { get; set; }
}
public class ProductUpdateDTO
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    public string Description { get; set; }
}
public class ProductDTO
{
    public Guid Id { get; set; }
    public string Image { get; set; }
    public Guid CategoryId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}

public class ProductWithStock
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? StockId { get; set; }
    public int? Quantity { get; set; }
    [Required]
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public int? Price { get; set; }
    public string? Color { get; set; }
    public char? Size { get; set; }



}

