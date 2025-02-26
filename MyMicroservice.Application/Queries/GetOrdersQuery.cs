using MediatR;
using MyMicroservice.Domain.Entities;
using System.Collections.Generic;

namespace MyMicroservice.Application.Queries;

public record GetOrdersQuery() : IRequest<IEnumerable<Order>>;
