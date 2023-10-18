using System.Windows;
using System.Windows.Media;

namespace imPhotoshop.Application.Common.Interfaces.Drawing;

public interface IDrawingOptions
{
    public Point StartPosition { get; set; } 
    public Point EndPosition { get; set; } 
    public double StrokeThickness { get; set; }
    public Color FillColor { get; set; } 
    public Color StrokeColor { get; set; } 
}
