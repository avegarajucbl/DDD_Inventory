namespace Inventory.Domain
{
    public class Payment
    {
        public decimal Amount { get; }
        public PaymentState PaymentState { get; set; }

        public Payment(decimal amount, PaymentState paymentState)
        {
            Amount = amount;
            PaymentState = paymentState;
        }
    }

    public enum PaymentState
    {
        Verified,
        Rejected
    }
}
