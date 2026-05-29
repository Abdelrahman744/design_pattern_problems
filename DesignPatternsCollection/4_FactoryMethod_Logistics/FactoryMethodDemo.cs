using System;

namespace DesignPatternsCollection.FactoryMethod
{
    public static class FactoryMethodDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 4: FACTORY METHOD — Logistics                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("  Scenario 1: Domestic order — using road transport.");
            Logistics roadLogistics = new RoadLogistics();
            roadLogistics.PlanDelivery();
            Console.WriteLine();

            Console.WriteLine("  Scenario 2: International order — using sea transport.");
            Logistics seaLogistics = new SeaLogistics();
            seaLogistics.PlanDelivery();
            Console.WriteLine();

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
