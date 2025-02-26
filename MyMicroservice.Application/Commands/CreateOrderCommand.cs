using MediatR;
using MyMicroservice.Domain.Entities;

namespace MyMicroservice.Application.Commands;

public record CreateOrderCommand(string ProductId, int Quantity) : IRequest<Order>;
