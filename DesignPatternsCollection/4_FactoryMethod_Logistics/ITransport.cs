using System;

namespace DesignPatternsCollection.FactoryMethod
{
    public interface ITransport
    {
        void Deliver();
    }

    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("  🚛 Truck: Delivering cargo by road in a container truck.");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("  🚢 Ship: Delivering cargo by sea in a shipping container.");
        }
    }
}
