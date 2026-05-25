// ============================================================================
// DECORATOR PATTERN — Pizza Ordering System
// ============================================================================
// THE PROBLEM:
// A pizzeria's POS system has a base Pizza. Customers can add any
// combination of extras: extra cheese, pepperoni, olives, mushrooms, etc.
//
// Subclassing every combination is impossible:
//   PlainPizza, CheesePizza, PepperoniPizza, CheesePepperoniPizza,
//   CheesePepperoniOlivePizza, ... → combinatorial explosion!
//
// THE SOLUTION:
// The Decorator pattern wraps objects at runtime. Each topping is a
// decorator that implements the same interface as the pizza itself.
// Decorators stack on top of each other, each adding its own cost
// and description — producing infinite combinations with minimal classes.
// ============================================================================

namespace DesignPatternsCollection.Decorator
{
    /// <summary>
    /// The Component interface.
    /// Both the base pizza and every decorator implement this,
    /// making them interchangeable to client code.
    /// </summary>
    public interface IPizza
    {
        /// <summary>Human-readable description of the pizza and its toppings.</summary>
        string GetDescription();

        /// <summary>Total price including all applied toppings.</summary>
        double GetCost();
    }
}
