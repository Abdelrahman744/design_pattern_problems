using System;
using DesignPatternsCollection.Strategy;
using DesignPatternsCollection.Observer;
using DesignPatternsCollection.Decorator;
using DesignPatternsCollection.FactoryMethod;
using DesignPatternsCollection.Adapter;
using DesignPatternsCollection.Singleton;

namespace DesignPatternsCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();
            Console.WriteLine("  ╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║         DESIGN PATTERNS COLLECTION — C# .NET              ║");
            Console.WriteLine("  ║     6 Independent GoF Patterns with Real-World Demos      ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            StrategyDemo.Run();
            PrintSeparator();

            ObserverDemo.Run();
            PrintSeparator();

            DecoratorDemo.Run();
            PrintSeparator();

            FactoryMethodDemo.Run();
            PrintSeparator();

            AdapterDemo.Run();
            PrintSeparator();

            SingletonDemo.Run();

            Console.WriteLine("  ══════════════════════════════════════════════════════════════");
            Console.WriteLine("  All 6 design pattern demos completed successfully!");
            Console.WriteLine("  ══════════════════════════════════════════════════════════════");
            Console.WriteLine();
        }

        private static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("  ──────────────────────────────────────────────────────────────");
            Console.WriteLine();
        }
    }
}
