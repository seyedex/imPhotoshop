using System.Windows;
using imPhotoshop.Application.Commands;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Tools;

namespace imPhotoshop.Application.Extensions.Commands;

public static class DrawCommandExtensions
{
    public static void Redraw(this DrawCommand drawCommand, UIElement element, IRedrawingTool redrawTool, IDrawingOptions drawingOptions)
    {
        drawCommand.Undo();
        drawCommand.Element = redrawTool.Redraw(element, drawingOptions);
        drawCommand.Execute();
    }
}
