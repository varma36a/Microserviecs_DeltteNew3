using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMicroservice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(string id)
    {
        var order = await _repository.GetByIdAsync(id);
        return order is not null ? Ok(order) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        await _repository.AddAsync(order);
        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(string id, [FromBody] Order order)
    {
        order.Id = id;
        return await _repository.UpdateAsync(order) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(string id)
    {
        return await _repository.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
