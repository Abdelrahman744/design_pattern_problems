namespace DesignPatternsCollection.Decorator
{
    // Abstract Decorator — wraps an IPizza and delegates calls to it by default.
    public abstract class PizzaDecorator : IPizza
    {
        protected readonly IPizza _pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string GetDescription() => _pizza.GetDescription();
        public virtual double GetCost() => _pizza.GetCost();
    }
}
