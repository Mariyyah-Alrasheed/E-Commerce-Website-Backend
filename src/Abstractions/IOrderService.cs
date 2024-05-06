using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IOrderService
{
    public IEnumerable<Order> FindAll();
    public IEnumerable<Order> FindByUserId(Guid userId);
    public Order? FindById(Guid id);
    public Order CreateOne(OrderCreateDTO newOrder);
    public bool DeleteOneById(Guid id);
    public bool DeleteOrderByUserId(Guid userId);
    public void Checkout(List<CheckoutDto> newOrder);
    // public IEnumerable<Stock> EditQuantity(int id);
    // public IEnumerable<Stock> EditeOne();
}