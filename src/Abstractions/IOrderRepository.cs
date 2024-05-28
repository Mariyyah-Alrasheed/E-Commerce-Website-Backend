using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IOrderRepository
{
    public IEnumerable<Order> FindAll();
    public IEnumerable<Order> FindByUserId(Guid userId);
    public Order? FindById(Guid id);
    public Order CreateOne(Order newOrder);
    public void DeleteOneById(Order id);
    public void DeleteOrderByUserId(Guid userId);
    public void UpdateOne(Order updateOrder);
}
