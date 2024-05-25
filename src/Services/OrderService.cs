
using AutoMapper;
using Hanan_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Services;

public class OrderService : IOrderService
{
    private IOrderItemService _orderItemService;
    private IOrderRepository _orderRepository;
    private IMapper _mapper;
    private IStockService _stockService;
    private IUserService _userService;
    // private IPaymentService _paymentService;
    private IAddressService _addressService;
    public OrderService(IOrderRepository orderRepository, IAddressService addressService,
     IMapper mapper, IStockService stockService, IOrderItemService orderItemService,
      IUserService userService)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _stockService = stockService;
        _orderItemService = orderItemService;
        _userService = userService;
        // _paymentService = paymentService;
        _addressService = addressService;
    }
    public Order CreateOne(OrderCreateDTO newCreatOrder)
    {
        Order newOrder = _mapper.Map<Order>(newCreatOrder);
        return _orderRepository.CreateOne(newOrder);
    }

    public void Checkout(List<CheckoutDto> checkedoutItems, string userId)
    {
        if (!Guid.TryParse(userId, out Guid userGuid))
        {
            Console.WriteLine("Invalid user ID format.");
            return;
        }



        var haveAddress = _addressService.FindOne(new Guid(userId));
        if (haveAddress is null)
        {
            Console.WriteLine("Add your address first");
        }
        else
        {
            Order order = new()
            {
                AddressId = haveAddress.Id,
                OrderDate = DateTime.Now,
                UserId = userGuid,
                Status = Enums.Status.InProgress,
            };
            _orderRepository.CreateOne(order);
            foreach (var item in checkedoutItems)
            {
                Stock? stock = _stockService.FindById(item.StockId);

                if (stock is null) { continue; }
                if (item.Quantity > stock.StockQuantity)
                {
                    Console.WriteLine($"Sold out {stock.Id}");
                    continue;
                }
                order.TotalAmount += stock.Price;
                OrderItem OrderItem = _mapper.Map<OrderItem>(item);
                OrderItem.Id = Guid.NewGuid();
                OrderItem.OrderId = order.Id;
                OrderItem.StockId = stock.Id;
                OrderItem.Quantity = item.Quantity;
                _orderItemService.CreateOne(OrderItem);
                stock.StockQuantity -= item.Quantity;
                _stockService.UpdateOne(stock);
                Console.WriteLine($" The stock {stock.StockQuantity}");

            }
            Console.WriteLine($"Total amount = {order.TotalAmount}");
        }
    }
    public IEnumerable<OrderCreateDTO> FindAll()
    {
        return _mapper.Map<IEnumerable<OrderCreateDTO>>(_orderRepository.FindAll());
    }
    public IEnumerable<Order> FindByUserId(Guid userId)
    {
        return _orderRepository.FindByUserId(userId);
    }
    public Order? FindById(Guid id)
    {
        return _orderRepository.FindById(id);
    }
    public bool DeleteOneById(Guid id)
    {
        Order? order = FindById(id);
        if (order is null)
        {
            return false;
        }
        else
        {
            _orderRepository.DeleteOneById(order);
        }
        return true;
    }
    public bool DeleteOrderByUserId(Guid userId)
    {
        IEnumerable<Order> unwantedUser = FindByUserId(userId);
        if (unwantedUser is not null)
        {
            return false;
        }
        _orderRepository.DeleteOrderByUserId(userId);
        return true;
    }
}
