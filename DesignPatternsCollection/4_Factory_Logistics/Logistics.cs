using System;

namespace DesignPatternsCollection.FactoryMethod
{
    // Creator — declares the Factory Method that subclasses must override.
    public abstract class Logistics
    {
        // Factory Method — subclasses decide which transport to create.
        public abstract ITransport CreateTransport();

        // Uses the factory method, then plans the delivery.
        public void PlanDelivery()
        {
            ITransport transport = CreateTransport();

            Console.WriteLine($"  [{GetType().Name}] Planning route and scheduling delivery...");
            transport.Deliver();
        }
    }

    // Concrete Creator — factory method returns a Truck.
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            Console.WriteLine("  [RoadLogistics] Factory Method → creating a Truck.");
            return new Truck();
        }
    }

    // Concrete Creator — factory method returns a Ship.
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            Console.WriteLine("  [SeaLogistics] Factory Method → creating a Ship.");
            return new Ship();
        }
    }
}
