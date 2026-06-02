// Component Interface — defines the contract for all pizzas and decorators.
namespace DesignPatternsCollection.Decorator
{
    public interface IPizza
    {
        string GetDescription();

        double GetCost();
    }
}
