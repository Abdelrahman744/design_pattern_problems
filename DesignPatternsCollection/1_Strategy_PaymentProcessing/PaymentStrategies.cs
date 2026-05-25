// ============================================================================
// Concrete Strategies — one class per payment method
// ============================================================================
// Each class encapsulates the full algorithm for one payment type.
// They are completely independent of each other and of the checkout system.
// ============================================================================

using System;

namespace DesignPatternsCollection.Strategy
{
    /// <summary>
    /// Processes payment via a traditional credit card.
    /// In production this would integrate with Stripe, Braintree, etc.
    /// </summary>
    public class CreditCardStrategy : IPaymentStrategy
    {
        private readonly string _cardNumber;

        public CreditCardStrategy(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay(double amount)
        {
            // Mask all but the last 4 digits for security
            string masked = new string('*', _cardNumber.Length - 4)
                          + _cardNumber[^4..];
            Console.WriteLine($"  [Credit Card] Charged ${amount:F2} to card {masked}.");
        }
    }

    /// <summary>
    /// Processes payment via PayPal using the customer's email.
    /// </summary>
    public class PayPalStrategy : IPaymentStrategy
    {
        private readonly string _email;

        public PayPalStrategy(string email)
        {
            _email = email;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"  [PayPal] Transferred ${amount:F2} from PayPal account '{_email}'.");
        }
    }

    /// <summary>
    /// Processes payment via Apple Pay (uses a device token in production).
    /// </summary>
    public class ApplePayStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"  [Apple Pay] Authorized ${amount:F2} via biometric confirmation.");
        }
    }

    /// <summary>
    /// Processes payment via cryptocurrency (e.g., Bitcoin wallet address).
    /// </summary>
    public class CryptoStrategy : IPaymentStrategy
    {
        private readonly string _walletAddress;

        public CryptoStrategy(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"  [Crypto] Sent ${amount:F2} equivalent in BTC to wallet {_walletAddress[..8]}...");
        }
    }
}
