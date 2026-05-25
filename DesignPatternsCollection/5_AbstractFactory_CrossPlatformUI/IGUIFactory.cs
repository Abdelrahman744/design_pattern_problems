// ============================================================================
// ABSTRACT FACTORY PATTERN — Cross-Platform UI
// ============================================================================
// THE PROBLEM:
// Your application must run on both Windows and macOS. It needs to render
// Buttons and Checkboxes that look native on each platform. If you mix
// a Windows button with a Mac checkbox, the UI looks broken and alien.
//
// THE SOLUTION:
// The Abstract Factory pattern provides an interface (IGUIFactory) that
// produces *families* of related objects (Button + Checkbox). Each
// platform has its own concrete factory (WindowsFactory, MacFactory)
// that returns matching widgets. Client code works exclusively against
// the abstract interfaces, so swapping platforms is a one-line change.
//
// KEY DIFFERENCE FROM FACTORY METHOD:
// • Factory Method — one method, one product, subclass decides.
// • Abstract Factory — multiple methods, a family of products, object decides.
// ============================================================================

using System;

namespace DesignPatternsCollection.AbstractFactory
{
    // ────────────────────────────────────────────────────────────────
    // Abstract Products — platform-agnostic widget contracts
    // ────────────────────────────────────────────────────────────────

    /// <summary>Any clickable button, regardless of OS.</summary>
    public interface IButton
    {
        void Render();
        void OnClick();
    }

    /// <summary>Any checkbox toggle, regardless of OS.</summary>
    public interface ICheckbox
    {
        void Render();
        void Toggle();
    }

    // ────────────────────────────────────────────────────────────────
    // Abstract Factory Interface
    // ────────────────────────────────────────────────────────────────

    /// <summary>
    /// Produces a consistent family of UI widgets for a given platform.
    /// Client code calls CreateButton() and CreateCheckbox() and is
    /// guaranteed to get components from the SAME platform.
    /// </summary>
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
}
