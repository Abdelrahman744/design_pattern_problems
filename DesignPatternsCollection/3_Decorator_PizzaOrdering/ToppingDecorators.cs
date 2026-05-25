// ============================================================================
// Concrete Decorators — individual toppings
// ============================================================================
// Each decorator wraps an IPizza, adds its own price and label, then
// delegates the rest to the inner object. They can be stacked freely:
//
//   new OliveDecorator(new PepperoniDecorator(new CheeseDecorator(new PlainPizza())))
//
// Result: "Plain Margherita Pizza + Extra Cheese + Pepperoni + Olives"
//         at $7.99 + $1.25 + $2.00 + $0.75 = $11.99
// ============================================================================

namespace DesignPatternsCollection.Decorator
{
    /// <summary>
    /// Adds extra cheese (+$1.25).
    /// </summary>
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
            => $"{_pizza.GetDescription()} + Extra Cheese";

        public override double GetCost()
            => _pizza.GetCost() + 1.25;
    }

    /// <summary>
    /// Adds pepperoni slices (+$2.00).
    /// </summary>
    public class PepperoniDecorator : PizzaDecorator
    {
        public PepperoniDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
            => $"{_pizza.GetDescription()} + Pepperoni";

        public override double GetCost()
            => _pizza.GetCost() + 2.00;
    }

    /// <summary>
    /// Adds black olives (+$0.75).
    /// </summary>
    public class OliveDecorator : PizzaDecorator
    {
        public OliveDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
            => $"{_pizza.GetDescription()} + Olives";

        public override double GetCost()
            => _pizza.GetCost() + 0.75;
    }
}
