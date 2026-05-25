// ============================================================================
// FACTORY METHOD PATTERN — Logistics Transport
// ============================================================================
// THE PROBLEM:
// You're building a logistics app that calculates routes and delivery times.
// Initially it only handles road transport (Trucks). Later, the company
// expands to sea logistics (Ships). The core planning logic is the same
// for both — only the transport vehicle creation differs.
//
// If you hard-code `new Truck()` everywhere, adding Ships means hunting
// down every instantiation site and wrapping it in conditionals.
//
// THE SOLUTION:
// The Factory Method pattern puts object creation behind an abstract
// method (CreateTransport) defined in a base class. Each subclass
// (RoadLogistics, SeaLogistics) overrides the method to return the
// appropriate vehicle. The planning logic in the base class works
// against the ITransport interface and never knows which vehicle it gets.
// ============================================================================

using System;

namespace DesignPatternsCollection.FactoryMethod
{
    // ────────────────────────────────────────────────────────────────
    // Product Interface — what every transport vehicle must do
    // ────────────────────────────────────────────────────────────────

    /// <summary>
    /// Common interface for all transport vehicles.
    /// The base Logistics class programs against this interface,
    /// not against concrete Truck or Ship classes.
    /// </summary>
    public interface ITransport
    {
        /// <summary>Carry out the delivery.</summary>
        void Deliver();
    }

    // ────────────────────────────────────────────────────────────────
    // Concrete Products
    // ────────────────────────────────────────────────────────────────

    /// <summary>Delivers goods over land by truck.</summary>
    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("  🚛 Truck: Delivering cargo by road in a container truck.");
        }
    }

    /// <summary>Delivers goods overseas by cargo ship.</summary>
    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("  🚢 Ship: Delivering cargo by sea in a shipping container.");
        }
    }
}
