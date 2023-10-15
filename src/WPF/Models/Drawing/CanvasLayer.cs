
using System.Windows;
using System.Windows.Controls;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Models.Drawing;

public class CanvasLayer : ILayer
{
    private string? _name;
    private readonly Canvas _canvas;

    public string? Name
    {
        get => _name;
        set => _name = value;
    }

    public Canvas Canvas => _canvas;

    public CanvasLayer()
    {
        _canvas = new Canvas();
    }

    public CanvasLayer(Canvas canvas)
    {
        _canvas = canvas;
    }

    public void AddElement(UIElement element)
    {
        if (element == null) return;
        Canvas.Children.Add(element);
    }

    public void RemoveElement(UIElement element)
    {
        Canvas.Children.Remove(element);
    }
}
