// ============================================================================
// Creator — the abstract Logistics class with the Factory Method
// ============================================================================
// The base class defines the skeleton of the planning workflow.
// The actual vehicle creation is deferred to subclasses via the
// abstract CreateTransport() method — this IS the Factory Method.
//
// Notice PlanDelivery() uses ITransport, never Truck or Ship directly.
// That's the decoupling the pattern provides.
// ============================================================================

using System;

namespace DesignPatternsCollection.FactoryMethod
{
    /// <summary>
    /// Abstract Creator.
    /// Contains the factory method <see cref="CreateTransport"/> and
    /// shared business logic that operates on ITransport.
    /// </summary>
    public abstract class Logistics
    {
        /// <summary>
        /// The FACTORY METHOD — subclasses decide which vehicle to create.
        /// This is the only method that differs between road and sea logistics.
        /// </summary>
        public abstract ITransport CreateTransport();

        /// <summary>
        /// Template business logic: create a transport and use it.
        /// This method is identical for all logistics types — only the
        /// object returned by CreateTransport() changes.
        /// </summary>
        public void PlanDelivery()
        {
            // Call the factory method to get the correct vehicle
            ITransport transport = CreateTransport();

            Console.WriteLine($"  [{GetType().Name}] Planning route and scheduling delivery...");
            transport.Deliver();
        }
    }

    // ────────────────────────────────────────────────────────────────
    // Concrete Creators — each overrides the factory method
    // ────────────────────────────────────────────────────────────────

    /// <summary>
    /// Road logistics — the factory method produces a Truck.
    /// </summary>
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            Console.WriteLine("  [RoadLogistics] Factory Method → creating a Truck.");
            return new Truck();
        }
    }

    /// <summary>
    /// Sea logistics — the factory method produces a Ship.
    /// </summary>
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            Console.WriteLine("  [SeaLogistics] Factory Method → creating a Ship.");
            return new Ship();
        }
    }
}
