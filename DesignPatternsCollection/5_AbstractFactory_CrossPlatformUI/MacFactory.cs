using System;

namespace DesignPatternsCollection.AbstractFactory
{
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

    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }
}
