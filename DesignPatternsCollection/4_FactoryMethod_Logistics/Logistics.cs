using System;

namespace DesignPatternsCollection.FactoryMethod
{
    public abstract class Logistics
    {
        public abstract ITransport CreateTransport();

        public void PlanDelivery()
        {
            ITransport transport = CreateTransport();

            Console.WriteLine($"  [{GetType().Name}] Planning route and scheduling delivery...");
            transport.Deliver();
        }
    }

    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            Console.WriteLine("  [RoadLogistics] Factory Method → creating a Truck.");
            return new Truck();
        }
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            Console.WriteLine("  [SeaLogistics] Factory Method → creating a Ship.");
            return new Ship();
        }
    }
}
