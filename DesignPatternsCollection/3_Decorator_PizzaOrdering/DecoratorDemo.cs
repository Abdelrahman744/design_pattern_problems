using System;

namespace DesignPatternsCollection.Decorator
{
    public static class DecoratorDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 3: DECORATOR — Pizza Ordering                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            IPizza order1 = new PlainPizza();
            Console.WriteLine($"  Order 1: {order1.GetDescription()}");
            Console.WriteLine($"           Cost: ${order1.GetCost():F2}");
            Console.WriteLine();

            IPizza order2 = new CheeseDecorator(new PlainPizza());
            Console.WriteLine($"  Order 2: {order2.GetDescription()}");
            Console.WriteLine($"           Cost: ${order2.GetCost():F2}");
            Console.WriteLine();

            IPizza order3 = new OliveDecorator(
                                new PepperoniDecorator(
                                    new CheeseDecorator(
                                        new PlainPizza())));
            Console.WriteLine($"  Order 3: {order3.GetDescription()}");
            Console.WriteLine($"           Cost: ${order3.GetCost():F2}");
            Console.WriteLine();

            IPizza order4 = new CheeseDecorator(
                                new CheeseDecorator(
                                    new PlainPizza()));
            Console.WriteLine($"  Order 4: {order4.GetDescription()}");
            Console.WriteLine($"           Cost: ${order4.GetCost():F2}");
            Console.WriteLine();
        }
    }
}
