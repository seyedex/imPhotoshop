
using imPhotoshop.WPF.Core.Interfaces.Commands;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using System.Windows;

namespace imPhotoshop.WPF.Models.Commands;

public class DrawCommand : ICommand
{
    private readonly ILayer _layer;
    private UIElement _element;

    public UIElement Element 
    { 
        get => _element; 
        set => _element = value; 
    }

    public DrawCommand(ILayer layer, UIElement element)
    {
        _layer = layer;
        Element = element;
    }


    public void Execute()
    {
        _layer.AddElement(Element);
    }

    public void Undo()
    {
        _layer.RemoveElement(Element);
    }
}
