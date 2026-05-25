// ============================================================================
// Mac Factory — concrete products and factory for macOS platform
// ============================================================================

using System;

namespace DesignPatternsCollection.AbstractFactory
{
    // ── macOS-specific concrete products ──

    /// <summary>A macOS-styled button with rounded corners and the Aqua look.</summary>
    public class MacButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("  [Mac Button] Rendering a rounded macOS Aqua-style button.");
        }

        public void OnClick()
        {
            Console.WriteLine("  [Mac Button] Click! Playing the macOS 'pop' sound.");
        }
    }

    /// <summary>A macOS-styled checkbox with the signature rounded toggle.</summary>
    public class MacCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("  [Mac Checkbox] Rendering a rounded macOS-style checkbox.");
        }

        public void Toggle()
        {
            Console.WriteLine("  [Mac Checkbox] Toggled! Showing a smooth animated check mark.");
        }
    }

    // ── Mac Factory ──

    /// <summary>
    /// Produces exclusively macOS-styled widgets.
    /// Swapping WindowsFactory for MacFactory in the client code
    /// re-skins the entire UI to look native on macOS.
    /// </summary>
    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }
}
