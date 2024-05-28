using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers;

public class OrderController : BaseController
{
    private IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    // [Authorize(Roles = "Admin")]

    public IEnumerable<OrderCreateDTO> FindAll()
    {
        return _orderService.FindAll();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Order> CreateOne([FromBody] OrderCreateDTO newOrder)
    {
        if (newOrder is null)
        {
            return BadRequest();
        }
        _orderService.CreateOne(newOrder);
        return CreatedAtAction(nameof(CreateOne), newOrder);
    }
    [Authorize(Roles = "Admin,Customer")]
    [HttpPost("checkout")]
    public ActionResult Checkout(List<CheckoutDto> newOrder)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _orderService.Checkout(newOrder, userId);
        return Ok();
    }

    [HttpGet("orders/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Order>> FindByUserId(Guid userId)
    {
        var customerOrder = _orderService.FindByUserId(userId);

        if (customerOrder is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(customerOrder);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Order> FindById(Guid id)
    {
        var order = _orderService.FindById(id);

        if (order is null)
        {
            return NotFound();
        }
        return order;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public ActionResult DeleteOneById(Guid id)
    {
        _orderService.DeleteOneById(id);
        return NoContent();
    }

    [HttpDelete("orders/{userId}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteOrderByUserId(Guid userId)
    {
        _orderService.DeleteOrderByUserId(userId);
        return NoContent();
    }
}
