using System.Windows;
using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.Application.Common.Interfaces.Tools;

public interface ITool
{
    public UIElement CreateElement(IDrawingOptions options);
}
