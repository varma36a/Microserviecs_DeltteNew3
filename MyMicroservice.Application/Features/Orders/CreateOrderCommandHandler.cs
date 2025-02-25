using MediatR;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyMicroservice.Application.Features.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.ProductId, request.Quantity);
            await _repository.AddAsync(order);
            //return order.Id;
            return Guid.Empty;
        }


        //public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        //{
        //    var order = new Order(request.ProductId, request.Quantity);
        //    await _repository.AddAsync(order);
        //    return order.Id;
        //}
    }
}