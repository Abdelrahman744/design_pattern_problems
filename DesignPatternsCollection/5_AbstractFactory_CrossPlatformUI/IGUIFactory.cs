using System;

namespace DesignPatternsCollection.AbstractFactory
{
    public interface IButton
    {
        void Render();
        void OnClick();
    }

    public interface ICheckbox
    {
        void Render();
        void Toggle();
    }

    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
}
