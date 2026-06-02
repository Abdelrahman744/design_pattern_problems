// Concrete Decorators — each adds a topping, extending description and cost.
namespace DesignPatternsCollection.Decorator
{
    // Adds extra cheese topping (+$1.25).
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
            => $"{_pizza.GetDescription()} + Extra Cheese";

        public override double GetCost()
            => _pizza.GetCost() + 1.25;
    }

    // Adds pepperoni topping (+$2.00).
    public class PepperoniDecorator : PizzaDecorator
    {
        public PepperoniDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
            => $"{_pizza.GetDescription()} + Pepperoni";

        public override double GetCost()
            => _pizza.GetCost() + 2.00;
    }

    // Adds olive topping (+$0.75).
    public class OliveDecorator : PizzaDecorator
    {
        public OliveDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
            => $"{_pizza.GetDescription()} + Olives";

        public override double GetCost()
            => _pizza.GetCost() + 0.75;
    }
}
