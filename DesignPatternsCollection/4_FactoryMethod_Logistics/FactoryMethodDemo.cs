// ============================================================================
// Factory Method Pattern Demo
// ============================================================================
// Shows how the same PlanDelivery() template method produces different
// vehicles depending on which concrete Logistics subclass is used.
// ============================================================================

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

            // --- Scenario 1: Domestic delivery → Road logistics ---
            Console.WriteLine("  Scenario 1: Domestic order — using road transport.");
            Logistics roadLogistics = new RoadLogistics();
            roadLogistics.PlanDelivery();
            Console.WriteLine();

            // --- Scenario 2: International delivery → Sea logistics ---
            Console.WriteLine("  Scenario 2: International order — using sea transport.");
            Logistics seaLogistics = new SeaLogistics();
            seaLogistics.PlanDelivery();
            Console.WriteLine();

            // --- Demonstrating polymorphism ---
            // Client code works with the abstract Logistics type.
            // It doesn't matter whether we pass Road or Sea — PlanDelivery()
            // uses the factory method internally to get the right vehicle.
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
