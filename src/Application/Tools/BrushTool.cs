using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using imPhotoshop.Application.Common.Interfaces.Tools;
using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.Application.Tools;

public class BrushTool : IRedrawingTool
{
    public UIElement CreateElement(IDrawingOptions options)
    {
        var polyline = new Polyline
        {
            StrokeThickness = options.StrokeThickness,
            Stroke = new SolidColorBrush(options.StrokeColor)
        };
        polyline.Points.Add(options.StartPosition);
        polyline.Points.Add(options.EndPosition);

        return polyline;
    }

    public UIElement Redraw(UIElement element, IDrawingOptions options)
    {
        if (element is not Polyline) return element;

        Polyline polyline = (element as Polyline);
        polyline.Points.Add(options.EndPosition);

        return polyline;
    }
}
