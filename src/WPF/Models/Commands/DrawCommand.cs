
using imPhotoshop.WPF.Core.Interfaces.Commands;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using System.Windows;

namespace imPhotoshop.WPF.Models.Commands;

public class DrawCommand : ICommand
{
    private readonly ILayer _layer;
    private readonly UIElement _element;
/*
    public UIElement Element 
    { 
        get => _element; 
        set => _element = value; 
    }
*/
    public DrawCommand(ILayer layer, UIElement element)
    {
        _layer = layer;
        _element = element;
    }


    public void Execute()
    {
        _layer.AddElement(_element);
    }

    public void Undo()
    {
        _layer.RemoveElement(_element);
    }
}
