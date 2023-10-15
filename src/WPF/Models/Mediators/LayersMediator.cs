
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using System;

namespace imPhotoshop.WPF.Models.Mediators;

public class LayersMediator : ILayersMediator
{
    public event Action<ILayer> ActiveLayerChanged;

    public void ChangeActiveLayer(ILayer layer)
    {
        ActiveLayerChanged?.Invoke(layer);
    }
}
