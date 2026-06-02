using System;

namespace DesignPatternsCollection.Strategy
{
    // Demo — shows strategies being swapped at runtime without if/else blocks.
    public static class StrategyDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 1: STRATEGY — Payment Processing                   ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Start with credit card, then swap strategies on the fly.
            Console.WriteLine("  Scenario 1: Customer selects Credit Card at checkout.");
            var checkout = new CheckoutService(
                new CreditCardStrategy("4111222233334444")
            );
            checkout.ProcessOrder(149.99);

            Console.WriteLine("  Scenario 2: Customer switches to PayPal.");
            checkout.SetPaymentStrategy(new PayPalStrategy("customer@email.com"));
            checkout.ProcessOrder(89.50);

            Console.WriteLine("  Scenario 3: Customer uses Apple Pay.");
            checkout.SetPaymentStrategy(new ApplePayStrategy());
            checkout.ProcessOrder(24.99);

            Console.WriteLine("  Scenario 4: Customer pays with Bitcoin.");
            checkout.SetPaymentStrategy(new CryptoStrategy("1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa"));
            checkout.ProcessOrder(500.00);
        }
    }
}
