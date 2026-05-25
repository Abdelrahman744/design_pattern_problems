// ============================================================================
// Checkout Service — the "Context" in Strategy terminology
// ============================================================================
// This class represents the e-commerce checkout flow.
// It does NOT know which payment method will be used. It simply holds
// a reference to IPaymentStrategy and delegates the work.
//
// KEY BENEFIT: When the business asks for a new payment method (say,
// Google Pay), you create ONE new class. CheckoutService stays untouched.
// ============================================================================

using System;

namespace DesignPatternsCollection.Strategy
{
    /// <summary>
    /// The Context class. Holds a strategy and delegates payment to it.
    /// </summary>
    public class CheckoutService
    {
        // ── The strategy is injected, not hard-coded ──
        private IPaymentStrategy _paymentStrategy;

        /// <summary>
        /// Inject the desired payment strategy at construction time.
        /// </summary>
        public CheckoutService(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        /// <summary>
        /// Swap the payment strategy at runtime (e.g., user changes mind
        /// on the checkout page).
        /// </summary>
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        /// <summary>
        /// Process the checkout.
        /// Notice this method has ZERO knowledge of credit cards, PayPal,
        /// crypto, or anything else — it just calls Pay().
        /// </summary>
        public void ProcessOrder(double amount)
        {
            Console.WriteLine($"\n  Processing order for ${amount:F2}...");
            _paymentStrategy.Pay(amount);
            Console.WriteLine("  Order complete!\n");
        }
    }
}
