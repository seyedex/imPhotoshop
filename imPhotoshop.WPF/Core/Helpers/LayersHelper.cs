
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Core.Helpers;

public static class LayersHelper
{
    public static ILayer CreateLayer(string name = "New Layer")
    {
        var newLayer = IoC.Get<ILayer>();
        newLayer.Name = name;
        return newLayer;
    }
}
