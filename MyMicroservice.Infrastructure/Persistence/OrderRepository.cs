using MyMicroservice.Domain.Entities;
using MyMicroservice.Domain.Interfaces;
using System.Threading.Tasks;

namespace MyMicroservice.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
}
