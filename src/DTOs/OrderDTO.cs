using System.ComponentModel.DataAnnotations;
using static sda_onsite_2_csharp_backend_teamwork.src.DTOs.OrderCreateDTO;
namespace sda_onsite_2_csharp_backend_teamwork.src.DTOs;

public class OrderCreateDTO
{
    public Guid AddressId { get; set; }
    public Guid UserId { get; set; }
    public int TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public enum Status { set, get }
    [Required]
    public Guid PaymentId { get; set; }

}
public class CheckoutDto
{
    public Guid StockId { get; set; }
    public int Quantity { get; set; }
}
public class OrderReadDto
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public Status Status { get; set; }
    public string PaymentId { get; set; }
}