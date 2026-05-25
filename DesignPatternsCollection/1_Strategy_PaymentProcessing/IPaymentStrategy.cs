// ============================================================================
// STRATEGY PATTERN — Payment Processing
// ============================================================================
// THE PROBLEM:
// You're building a checkout system for an e-commerce app. Initially you
// only accept Credit Cards. Business then demands PayPal, Apple Pay, and
// Crypto. If you hard-code each payment method into the checkout logic
// with if/else branches, adding a new method means modifying existing,
// tested code — violating the Open/Closed Principle.
//
// THE SOLUTION:
// Extract each payment algorithm into its own class behind a common
// interface (IPaymentStrategy). The checkout system holds a reference
// to the interface and delegates the work. Adding a new payment type
// means writing ONE new class — zero changes to existing code.
// ============================================================================

namespace DesignPatternsCollection.Strategy
{
    /// <summary>
    /// The Strategy interface.
    /// Every payment method must implement this single contract.
    /// </summary>
    public interface IPaymentStrategy
    {
        /// <summary>
        /// Process a payment for the given amount.
        /// Each concrete strategy handles the details internally.
        /// </summary>
        void Pay(double amount);
    }
}
