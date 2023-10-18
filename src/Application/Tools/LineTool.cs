using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Tools;

namespace imPhotoshop.Application.Tools;

public class LineTool : IRedrawingTool
{
    public UIElement CreateElement(IDrawingOptions options)
    {
        return new Line
        {
            X1 = options.StartPosition.X,
            Y1 = options.StartPosition.Y, 
            X2 = options.EndPosition.X,
            Y2 = options.EndPosition.Y, 
            StrokeThickness = options.StrokeThickness,
            Stroke = new SolidColorBrush(options.StrokeColor)
        };
    }

    public UIElement Redraw(UIElement element, IDrawingOptions options)
    {
        if (element is not Line) return element;

        var line = (element as Line);
        line.X2 = options.EndPosition.X;
        line.Y2 = options.EndPosition.Y;

        return line;
    }
}
