using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IStockService
{
    public IEnumerable<Stock> FindAll();
    public IEnumerable<Stock> FindByProductId(Guid productId);
    public Stock? FindById(Guid id);
    public Stock CreateOne(StockCreatDto newProduct);
    public bool DeletOneById(Guid id);
    public bool DeletProductById(Guid productId);
    // public IEnumerable<Stock> EditQuantity(int id);
    // public IEnumerable<Stock> EditeOne();


}