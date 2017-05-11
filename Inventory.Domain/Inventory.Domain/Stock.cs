using System.Collections.Generic;
using System.Linq;

namespace Inventory.Domain
{
    public class Stock
    {
        private IList<StockProduct> _stockProducts { get; set; } = new List<StockProduct>();
        public IReadOnlyCollection<StockProduct> StockProducts => _stockProducts.ToList();

        public Stock(IEnumerable<StockProduct> stockProducts)
        {
            _stockProducts = stockProducts.ToList();
        }

        public void ReduceStock(Order order)
        {
            foreach (var product in order.Products)
            {
                var stockedProduct = _stockProducts.First(sp => sp.ProductId == product.ProductId);

                stockedProduct.SetQuantity(stockedProduct.TotalQuantity - product.Quantity);
            }
        }
    }

    public class StockProduct
    {
        public long ProductId { get; }
        public int TotalQuantity { get; private set; }
        public string Name { get; }

        public StockProduct(long productId,
                            int totalQuantity,
                            string name)
        {
            ProductId = productId;
            TotalQuantity = totalQuantity;
            Name = name;
        }

        internal void SetQuantity(int quantity)
        {
            TotalQuantity = quantity;
        }
    }
}