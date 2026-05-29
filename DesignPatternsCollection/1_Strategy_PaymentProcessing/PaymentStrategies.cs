using System;

namespace DesignPatternsCollection.Strategy
{
    public class CreditCardStrategy : IPaymentStrategy
    {
        private readonly string _cardNumber;

        public CreditCardStrategy(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay(double amount)
        {
            string masked = new string('*', _cardNumber.Length - 4)
                          + _cardNumber[^4..];
            Console.WriteLine($"  [Credit Card] Charged ${amount:F2} to card {masked}.");
        }
    }

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

    public class ApplePayStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"  [Apple Pay] Authorized ${amount:F2} via biometric confirmation.");
        }
    }

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
