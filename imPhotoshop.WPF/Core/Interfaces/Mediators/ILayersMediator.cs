
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using System;

namespace imPhotoshop.WPF.Core.Interfaces.Mediators;

public interface ILayersMediator
{
    public event Action<ILayer> ActiveLayerChanged;

    public void ChangeActiveLayer(ILayer layer);
}
