// ============================================================================
// Windows Factory — concrete products and factory for Windows platform
// ============================================================================

using System;

namespace DesignPatternsCollection.AbstractFactory
{
    // ── Windows-specific concrete products ──

    /// <summary>A Windows-styled button with the classic look and feel.</summary>
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("  [Windows Button] Rendering a rectangular Windows-style button.");
        }

        public void OnClick()
        {
            Console.WriteLine("  [Windows Button] Click! Playing the Windows 'ding' sound.");
        }
    }

    /// <summary>A Windows-styled checkbox with a square check mark.</summary>
    public class WindowsCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("  [Windows Checkbox] Rendering a square Windows-style checkbox.");
        }

        public void Toggle()
        {
            Console.WriteLine("  [Windows Checkbox] Toggled! Showing a blue check mark.");
        }
    }

    // ── Windows Factory ──

    /// <summary>
    /// Produces exclusively Windows-styled widgets.
    /// Both CreateButton() and CreateCheckbox() return Windows variants,
    /// guaranteeing a consistent native Windows look.
    /// </summary>
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }
}
