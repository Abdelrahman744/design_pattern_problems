// Strategy Interface — defines the contract all payment methods must follow.
namespace DesignPatternsCollection.Strategy
{
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }
}
