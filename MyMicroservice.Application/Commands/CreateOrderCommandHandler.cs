using MediatR;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MyMicroservice.Application.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly MongoDbContext _context;

    public CreateOrderCommandHandler(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.ProductId, request.Quantity);
        await _context.Orders.InsertOneAsync(order, cancellationToken: cancellationToken);
        return order;
    }
}
