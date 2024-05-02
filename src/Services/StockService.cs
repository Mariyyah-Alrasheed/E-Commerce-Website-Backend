
using AutoMapper;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Services;

public class StockService : IStockService
{
    private IStockRepository _stockRepository;
    private IMapper _mapper;

    public StockService(IStockRepository stockRepository, IMapper mapper)
    {
        _stockRepository = stockRepository;
        _mapper = mapper;

    }

    public Stock CreateOne(StockCreatDto newCreatStock)
    {

        Stock newStock = _mapper.Map<Stock>(newCreatStock);


        return _stockRepository.CreateOne(newStock);
    }

    // public IEnumerable<Stock> EditeOne()
    // {
    //     throw new NotImplementedException();
    // }

    public IEnumerable<Stock> FindAll()
    {
        return _stockRepository.FindAll();
    }

    public IEnumerable<Stock> FindByProductId(Guid productId)
    {
        // 
        return _stockRepository.FindByProductId(productId);

    }
    public Stock? FindById(Guid id)
    {
        // 
        return _stockRepository.FindById(id);

    }

    public bool DeletOneById(Guid id)
    {

        return _stockRepository.DeletOneById(id);
    }
    public bool DeletProductById(Guid productId)
    {
        return _stockRepository.DeletProductById(productId);
    }

    // public IEnumerable<Stock> EditItem(int id)
    // {
    //     throw new NotImplementedException();
    // }
}