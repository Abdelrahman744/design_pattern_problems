using System;

namespace DesignPatternsCollection.Strategy
{
    public class CheckoutService
    {
        private IPaymentStrategy _paymentStrategy;

        public CheckoutService(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ProcessOrder(double amount)
        {
            Console.WriteLine($"\n  Processing order for ${amount:F2}...");
            _paymentStrategy.Pay(amount);
            Console.WriteLine("  Order complete!\n");
        }
    }
}
