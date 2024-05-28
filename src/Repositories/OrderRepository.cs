using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Repositories;

public class OrderRepository : IOrderRepository
{
    private DbSet<Order> _order;
    private DatabaseContext _databaseContext;
    public OrderRepository(DatabaseContext databaseContext)
    {
        _order = databaseContext.Order;
        _databaseContext = databaseContext;
    }
    public Order CreateOne(Order newOrder)
    {
        _order.Add(newOrder);
        _databaseContext.SaveChanges();
        return newOrder;
    }
    public IEnumerable<Order> FindAll()
    {
        return _order;
    }
    public IEnumerable<Order> FindByUserId(Guid userId)
    {
        return _order.Where(item => item.UserId == userId);
    }
    public Order? FindById(Guid id)
    {
        return _order.FirstOrDefault(item => item.Id == id);
    }
    public void DeleteOneById(Order order)
    {
        _order.Remove(order);
        _databaseContext.SaveChanges();
    }
    public void DeleteOrderByUserId(Guid userId)
    {
        var itemsToRemove = _order.Where(item => item.UserId == userId);
        _order.RemoveRange(itemsToRemove);
    }

    public void UpdateOne(Order updateOrder)
    {
        _order.Update(updateOrder);
        _databaseContext.SaveChanges(); ;
    }
}