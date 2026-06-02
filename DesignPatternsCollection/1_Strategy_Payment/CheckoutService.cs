using System;

namespace DesignPatternsCollection.Strategy
{
    // Context — holds a reference to a strategy and delegates payment to it.
    public class CheckoutService
    {
        private IPaymentStrategy _paymentStrategy;

        public CheckoutService(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Allows swapping the strategy at runtime.
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Delegates the actual payment to whichever strategy is set.
        public void ProcessOrder(double amount)
        {
            Console.WriteLine($"\n  Processing order for ${amount:F2}...");
            _paymentStrategy.Pay(amount);
            Console.WriteLine("  Order complete!\n");
        }
    }
}
