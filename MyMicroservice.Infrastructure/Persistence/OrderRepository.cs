using MongoDB.Driver;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMicroservice.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly MongoDbContext _context;

    public OrderRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.Find(order => true).ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(string id)
    {
        return await _context.Orders.Find(order => order.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.InsertOneAsync(order);
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        var result = await _context.Orders.ReplaceOneAsync(o => o.Id == order.Id, order);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var result = await _context.Orders.DeleteOneAsync(order => order.Id == id);
        return result.DeletedCount > 0;
    }
}
