// ============================================================================
// Abstract Decorator — the base wrapper all toppings extend
// ============================================================================
// This class implements IPizza (so it IS-A pizza to the outside world)
// and holds a reference to another IPizza (so it HAS-A pizza inside).
// By default it delegates everything to the wrapped pizza.
// Concrete decorators override to add their own behaviour.
// ============================================================================

namespace DesignPatternsCollection.Decorator
{
    /// <summary>
    /// Abstract base for all pizza decorators.
    /// Implements IPizza and wraps another IPizza instance.
    /// </summary>
    public abstract class PizzaDecorator : IPizza
    {
        /// <summary>The pizza (or decorator) this wrapper surrounds.</summary>
        protected readonly IPizza _pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        // Default behaviour: pass through to the wrapped object.
        public virtual string GetDescription() => _pizza.GetDescription();
        public virtual double GetCost() => _pizza.GetCost();
    }
}
