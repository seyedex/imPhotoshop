using System.Windows;
using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.Application.Common.Interfaces.Tools;

public interface IRedrawingTool : ITool
{
    public UIElement Redraw(UIElement element, IDrawingOptions options);
}
