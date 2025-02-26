using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Application.Commands;
using MyMicroservice.Application.Queries;
using MyMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMicroservice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        var orders = await _mediator.Send(new GetOrdersQuery());
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var order = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
    }
}
