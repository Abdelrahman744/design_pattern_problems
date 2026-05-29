using System;

namespace DesignPatternsCollection.AbstractFactory
{
    public static class AbstractFactoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 5: ABSTRACT FACTORY — Cross-Platform UI            ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.WriteLine("  Scenario 1: Running on Windows");
            Console.WriteLine("  ─────────────────────────────");
            RenderApplication(new WindowsFactory());
            Console.WriteLine();

            Console.WriteLine("  Scenario 2: Running on macOS");
            Console.WriteLine("  ────────────────────────────");
            RenderApplication(new MacFactory());
            Console.WriteLine();
        }

        private static void RenderApplication(IGUIFactory factory)
        {
            IButton button     = factory.CreateButton();
            ICheckbox checkbox = factory.CreateCheckbox();

            button.Render();
            button.OnClick();
            checkbox.Render();
            checkbox.Toggle();
        }
    }
}
