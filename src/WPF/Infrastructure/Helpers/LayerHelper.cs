using imPhotoshop.Infrastructure.Drawing;
using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.WPF.Infrastructure.Helpers;

public static class LayerHelper
{
    public static ILayer CreateLayer()
    {
        return new CanvasLayer { Name = "New Layer" };
    }
}
