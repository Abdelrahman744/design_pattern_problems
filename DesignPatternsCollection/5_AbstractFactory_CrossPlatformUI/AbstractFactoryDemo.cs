// ============================================================================
// Abstract Factory Pattern Demo
// ============================================================================
// Shows how client code works with IGUIFactory without knowing whether
// it's rendering Windows or Mac widgets. The factory is the single
// decision point — everything else is platform-agnostic.
// ============================================================================

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

            // --- Scenario 1: Application boots on Windows ---
            Console.WriteLine("  Scenario 1: Running on Windows");
            Console.WriteLine("  ─────────────────────────────");
            RenderApplication(new WindowsFactory());
            Console.WriteLine();

            // --- Scenario 2: Application boots on macOS ---
            Console.WriteLine("  Scenario 2: Running on macOS");
            Console.WriteLine("  ────────────────────────────");
            RenderApplication(new MacFactory());
            Console.WriteLine();
        }

        /// <summary>
        /// Client code that works ONLY with the abstract IGUIFactory.
        /// It has no idea whether it's rendering Windows or Mac widgets —
        /// it just asks the factory for a button and a checkbox.
        ///
        /// THIS IS THE POWER OF THE ABSTRACT FACTORY:
        /// You can pass ANY concrete factory, and the entire UI
        /// renders a matching family of components automatically.
        /// </summary>
        private static void RenderApplication(IGUIFactory factory)
        {
            // Create a family of matching widgets
            IButton button     = factory.CreateButton();
            ICheckbox checkbox = factory.CreateCheckbox();

            // Use them — client code is completely platform-agnostic
            button.Render();
            button.OnClick();
            checkbox.Render();
            checkbox.Toggle();
        }
    }
}
