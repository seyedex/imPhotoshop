
using System.Windows;
using System.Windows.Media;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Models.Drawing;

public class DrawingOptions : IDrawingOptions
{
    private double _strokeThickness = 10;

    public Point StartPosition { get; set; }
    public Point EndPosition { get; set; }

    public double StrokeThickness 
    {
        get => _strokeThickness;
        set
        {
            if (value >= 0 && value <= 1000)
                _strokeThickness = value;
        }
    }

    public Color FillColor { get; set; } = Colors.White;
    
    public Color StrokeColor { get; set; } = Colors.White;
}
