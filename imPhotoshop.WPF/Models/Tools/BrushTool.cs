
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using imPhotoshop.WPF.Core.Interfaces.Tools;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Models.Tools;

public class BrushTool : ITool
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
