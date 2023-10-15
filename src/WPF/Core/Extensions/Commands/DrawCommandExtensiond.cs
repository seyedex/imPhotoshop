
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using imPhotoshop.WPF.Core.Interfaces.Tools;
using imPhotoshop.WPF.Models.Commands;
using System.Windows;

namespace imPhotoshop.WPF.Core.Extensions.Commands;

public static class DrawCommandExtensiond
{
    public static void Redraw(this DrawCommand drawCommand, UIElement element, ITool tool, IDrawingOptions drawingOptions)
    {
        drawCommand.Undo();
        //drawCommand.Element = tool.Redraw(element, drawingOptions);
        drawCommand.Execute();
    }
}
