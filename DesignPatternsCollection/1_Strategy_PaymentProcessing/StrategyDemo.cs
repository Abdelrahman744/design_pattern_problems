// ============================================================================
// Strategy Pattern Demo
// ============================================================================
// This demo simulates a customer going through checkout with different
// payment methods, showing how the strategy can be swapped at runtime.
// ============================================================================

using System;

namespace DesignPatternsCollection.Strategy
{
    public static class StrategyDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 1: STRATEGY — Payment Processing                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // --- Scenario 1: Customer pays with a Credit Card ---
            Console.WriteLine("  Scenario 1: Customer selects Credit Card at checkout.");
            var checkout = new CheckoutService(
                new CreditCardStrategy("4111222233334444")
            );
            checkout.ProcessOrder(149.99);

            // --- Scenario 2: Same checkout, customer switches to PayPal ---
            Console.WriteLine("  Scenario 2: Customer switches to PayPal.");
            checkout.SetPaymentStrategy(new PayPalStrategy("customer@email.com"));
            checkout.ProcessOrder(89.50);

            // --- Scenario 3: Apple Pay ---
            Console.WriteLine("  Scenario 3: Customer uses Apple Pay.");
            checkout.SetPaymentStrategy(new ApplePayStrategy());
            checkout.ProcessOrder(24.99);

            // --- Scenario 4: Cryptocurrency ---
            Console.WriteLine("  Scenario 4: Customer pays with Bitcoin.");
            checkout.SetPaymentStrategy(new CryptoStrategy("1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa"));
            checkout.ProcessOrder(500.00);
        }
    }
}
