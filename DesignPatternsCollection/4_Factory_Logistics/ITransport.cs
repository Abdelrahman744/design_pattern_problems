using System;

namespace DesignPatternsCollection.FactoryMethod
{
    // Product Interface — all transport types must implement Deliver().
    public interface ITransport
    {
        void Deliver();
    }

    // Concrete Product — delivers cargo by road.
    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("  🚛 Truck: Delivering cargo by road in a container truck.");
        }
    }

    // Concrete Product — delivers cargo by sea.
    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("  🚢 Ship: Delivering cargo by sea in a shipping container.");
        }
    }
}
