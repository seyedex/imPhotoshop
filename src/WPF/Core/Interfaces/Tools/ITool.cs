
using System.Windows;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Core.Interfaces.Tools;

public interface ITool
{
    public UIElement CreateElement(IDrawingOptions options);
    public UIElement Redraw(UIElement element, IDrawingOptions options);
}
