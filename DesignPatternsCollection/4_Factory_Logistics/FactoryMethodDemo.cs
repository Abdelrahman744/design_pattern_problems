using System;

namespace DesignPatternsCollection.FactoryMethod
{
    // Demo — creates different logistics and lets the factory method pick the transport.
    public static class FactoryMethodDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 4: FACTORY METHOD — Logistics                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Each subclass returns a different transport via its factory method.
            Console.WriteLine("  Scenario 1: Domestic order — using road transport.");
            Logistics roadLogistics = new RoadLogistics();
            roadLogistics.PlanDelivery();
            Console.WriteLine();

            Console.WriteLine("  Scenario 2: International order — using sea transport.");
            Logistics seaLogistics = new SeaLogistics();
            seaLogistics.PlanDelivery();
            Console.WriteLine();

            // Polymorphism — client uses the base type, factory method handles the rest.
            Console.WriteLine("  Scenario 3: Polymorphic dispatch (client uses base type).");
            Logistics[] allLogistics = { new RoadLogistics(), new SeaLogistics() };
            foreach (Logistics logistics in allLogistics)
            {
                logistics.PlanDelivery();
            }
            Console.WriteLine();
        }
    }
}
