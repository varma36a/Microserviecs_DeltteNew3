using MediatR;
using MongoDB.Driver;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyMicroservice.Application.Queries;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
{
    private readonly MongoDbContext _context;

    public GetOrdersQueryHandler(MongoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Orders.Find(order => true).ToListAsync(cancellationToken);
    }
}
