
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace imPhotoshop.WPF.Core.Collections;

public class LayerCollection : ILayerCollection
{
    public BindableCollection<ILayer> _layers = new();

    public void Add(ILayer layer)
    {
        _layers.Add(layer); 
    }

    public void Remove(ILayer layer)
    {
        _layers.Remove(layer);
    }

    public List<ILayer> ToList()
    {
        return _layers.ToList();
    }

    public BindableCollection<ILayer> ToBindableCollection()
    {
        return _layers;
    }

}
