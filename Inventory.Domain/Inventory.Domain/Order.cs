using System.Collections.Generic;
using System.Linq;

namespace Inventory.Domain
{
    public class Order
    {
        public Payment Payment { get; }
        public IReadOnlyCollection<Product> Products { get; }

        public Order(Payment payment, IEnumerable<Product> products)
        {
            Payment = payment;
            Products = products.ToList();
        }
    }

    public class Product
    {
        public long ProductId { get; }
        public int Quantity { get; }
        public string Name { get; }

        public Product(long productId, int quantity, string name)
        {
            ProductId = productId;
            Quantity = quantity;
            Name = name;
        }
    }
    
}
