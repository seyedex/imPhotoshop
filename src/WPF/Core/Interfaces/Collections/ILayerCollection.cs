
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using System.Collections.Generic;

namespace imPhotoshop.WPF.Core.Interfaces.Collections;

public interface ILayerCollection
{
    public void Add(ILayer layer);
    public void Remove(ILayer layer);
    public List<ILayer> ToList();
    public BindableCollection<ILayer> ToBindableCollection();
}
