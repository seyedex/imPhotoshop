using System.Collections.ObjectModel;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Infrastructure.Collections;

public class ObservableLayerCollection : IObservableLayerCollection
{
    private ObservableCollection<ILayer> _layers;

    public IEnumerable<ILayer> Items => _layers;

    public ObservableCollection<ILayer> ObservableItems => _layers;

    public ObservableLayerCollection()
    {
        _layers = new ObservableCollection<ILayer>();
    }

    public ObservableLayerCollection(IEnumerable<ILayer> layers)
    {
        _layers = new ObservableCollection<ILayer>(layers);
    }

    public void Add(ILayer layer)
    {
        _layers.Add(layer);
    }

    public void Remove(ILayer layer)
    {
        _layers.Remove(layer);
    }

    public void Clear()
    {
        _layers.Clear();
    }

    public bool Contains(ILayer layer)
    {
        return _layers.Contains(layer);
    }

    public List<ILayer> ToList()
    {
        return _layers.ToList();
    }
}
