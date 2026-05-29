// ============================================================================
//                    DESIGN PATTERNS COLLECTION
//              6 Independent GoF Pattern Examples in C#
// ============================================================================
// This is the main entry point. Each pattern lives in its own folder
// with its own classes, interfaces, and demo. They are completely
// decoupled from each other — no shared state, no cross-references.
//
// This Program.cs simply runs each demo in sequence so you can see
// all 6 patterns in action from a single console run.
// ============================================================================
//
// PATTERNS INCLUDED:
// ┌─────┬──────────────────┬──────────────────────────────────────────────┐
// │  #  │ Pattern          │ Real-World Scenario                         │
// ├─────┼──────────────────┼──────────────────────────────────────────────┤
// │  1  │ Strategy         │ E-commerce payment processing               │
// │  2  │ Observer         │ Order status notifications                  │
// │  3  │ Decorator        │ Pizzeria point-of-sale customisation        │
// │  4  │ Factory Method   │ Logistics transport dispatching             │
// │  5  │ Abstract Factory │ Cross-platform UI rendering                 │
// │  6  │ Singleton        │ Game scoreboard                             │
// └─────┴──────────────────┴──────────────────────────────────────────────┘
// ============================================================================

using System;
using DesignPatternsCollection.Strategy;
using DesignPatternsCollection.Observer;
using DesignPatternsCollection.Decorator;
using DesignPatternsCollection.FactoryMethod;
using DesignPatternsCollection.AbstractFactory;
using DesignPatternsCollection.Singleton;

namespace DesignPatternsCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            // ── Header ──
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();
            Console.WriteLine("  ╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║         DESIGN PATTERNS COLLECTION — C# .NET              ║");
            Console.WriteLine("  ║     6 Independent GoF Patterns with Real-World Demos      ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // ────────────────────────────────────────────────────────────
            // Run each pattern's self-contained demo
            // ────────────────────────────────────────────────────────────

            // 1. STRATEGY — Payment Processing
            StrategyDemo.Run();
            PrintSeparator();

            // 2. OBSERVER — Order Notifications
            ObserverDemo.Run();
            PrintSeparator();

            // 3. DECORATOR — Pizza Ordering
            DecoratorDemo.Run();
            PrintSeparator();

            // 4. FACTORY METHOD — Logistics Transport
            FactoryMethodDemo.Run();
            PrintSeparator();

            // 5. ABSTRACT FACTORY — Cross-Platform UI
            AbstractFactoryDemo.Run();
            PrintSeparator();

            // 6. SINGLETON — Game Scoreboard
            SingletonDemo.Run();

            // ── Footer ──
            Console.WriteLine("  ══════════════════════════════════════════════════════════════");
            Console.WriteLine("  All 6 design pattern demos completed successfully!");
            Console.WriteLine("  ══════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }

        /// <summary>Prints a visual separator between pattern demos.</summary>
        private static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("  ──────────────────────────────────────────────────────────────");
            Console.WriteLine();
        }
    }
}
