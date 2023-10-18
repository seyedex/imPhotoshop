using System.Windows;
using imPhotoshop.Application.Common.Interfaces.Commands;
using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.Application.Commands;

public class DrawCommand : ICommand
{
    private readonly ILayer _layer;
    private UIElement _element;

    public ILayer Layer => _layer;
    public UIElement Element
    {
        get => _element;
        set => _element = value;
    }

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
