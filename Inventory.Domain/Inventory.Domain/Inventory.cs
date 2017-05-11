
namespace Inventory.Domain
{
    public class Inventory
    {
        public Stock Stock { get; }

        public Inventory(Stock stock)
        {
            Stock = stock;
        }

        public void AdjustStockLevels(Order order)
        {
            if (order.Payment.PaymentState == PaymentState.Verified)
            {
                ReduceStockLevels(order);
            }
        }

        private void ReduceStockLevels(Order order)
        {
            Stock.ReduceStock(order);
        }
    }
}
