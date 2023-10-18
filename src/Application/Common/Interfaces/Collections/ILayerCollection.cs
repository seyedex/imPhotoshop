using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.Application.Common.Interfaces.Collections;

public interface ILayerCollection
{
    public IEnumerable<ILayer> Items { get; }
    public int Count { get; }

    public void Add(ILayer layer);
    public void Insert(int index, ILayer layer);
    public void Remove(ILayer layer);
    public void Clear();
    public bool Contains(ILayer layer);
    public int IndexOf(ILayer layer);
    public List<ILayer> ToList();
}
