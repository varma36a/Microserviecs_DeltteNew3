using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMicroservice.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Order(string productId, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
