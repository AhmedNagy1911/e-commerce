using API.DTOs;
using Core.Entites.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(IUnitOfWork unit, IPaymentService paymentService) : BaseApiController
{
    [HttpGet("orders")]
    public async Task<ActionResult<IReadOnlyList<Order>>> GetOrders([FromQuery] OrderSpecParams specParams)
    {
        var spec = new OrderSpecification(specParams);

        return await CreatePageResult(unit.Repository<Order>(),
            spec, specParams.PageIndex, specParams.PageSize);
    }

    //[HttpGet("orders/{id:int}")]
    //public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    //{
    //    var spec = new OrderSpecification(id);

    //    var order = await unit.Repository<Order>().GetEntityWithSpec(spec);

    //    if (order == null) return BadRequest("No order with that Id");

    //    return order.ToDto();
    //}

    //[HttpPost("orders/refund/{id:int}")]
    //public async Task<ActionResult<OrderDto>> RefundOrder(int id)
    //{
    //    var spec = new OrderSpecification(id);

    //    var order = await unit.Repository<Order>().GetEntityWithSpec(spec);

    //    if (order == null) return BadRequest("No order with that Id");

    //    if (order.Status == OrderStatus.Pending)
    //        return BadRequest("Payment not received for this order");

    //    var result = await paymentService.RefundPayment(order.PaymentIntentId);

    //    if (result == "succeeded")
    //    {
    //        order.Status = OrderStatus.Refunded;

    //        await unit.Complete();

    //        return order.ToDto();
    //    }

    //    return BadRequest("Problem refunding order");
    //}
}