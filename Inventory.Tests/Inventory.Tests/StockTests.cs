using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Inventory.Domain;

using Xunit;

namespace Inventory.Tests
{
    public class StockTests
    {
        private const int ORDERED_PRODUCT_QUANTITY = 3;
        private const string PRODUCT_NAME = "FancyProduct";
        private const int PRODUCT_ID_ONE = 1;
        private const int TOTAL_QUANTITY = 100;

        [Fact]
        public void GivenAnOrderWithOneProduct_WhenPaymentIsVerified_ReducesStock()
        {
            int productId = PRODUCT_ID_ONE;

            var payment = new Payment(amount: 12, paymentState: PaymentState.Verified);

            var orderedProduct = new Product(productId: productId,
                                             quantity: ORDERED_PRODUCT_QUANTITY,
                                             name: PRODUCT_NAME);
            List<Product> orderedProducts = new List<Product> { orderedProduct };

            var stockProducts = GetDummyStock();

            var order = new Order(payment: payment, products: orderedProducts);
            var stock = new Stock(stockProducts);

            var inventory = new Domain.Inventory(stock: stock);
            inventory.AdjustStockLevels(order: order);

            var stockProduct = inventory.Stock.StockProducts.First(predicate: sp => sp.ProductId == PRODUCT_ID_ONE);

            stockProduct.TotalQuantity.Should().Be(TOTAL_QUANTITY - ORDERED_PRODUCT_QUANTITY);
        }

        private IEnumerable<StockProduct> GetDummyStock()
        {
            var stockProduct = new StockProduct(PRODUCT_ID_ONE, TOTAL_QUANTITY, PRODUCT_NAME);

            return new List<StockProduct> { stockProduct };
        }
    }
}
