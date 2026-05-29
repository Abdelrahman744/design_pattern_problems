using System;

namespace DesignPatternsCollection.AbstractFactory
{
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

    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }
}
