using MediatR;
using System;

namespace MyMicroservice.Application.Features.Orders
{
    public record CreateOrderCommand(string ProductId, int Quantity) : IRequest<Guid>;

}