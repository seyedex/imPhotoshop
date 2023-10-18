using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Infrastructure.Collections;

public class LayerCollection : ILayerCollection
{
    private IList<ILayer> _layers;

    public IEnumerable<ILayer> Items => _layers;

    public LayerCollection()
    {
        _layers = new List<ILayer>();
    }
    
    public LayerCollection(IEnumerable<ILayer> layers)
    {
        _layers = new List<ILayer>(layers);
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
