using System.Collections.ObjectModel;
using imPhotoshop.Application.Common.Interfaces.Drawing;

namespace imPhotoshop.Application.Common.Interfaces.Collections;

public interface IObservableLayerCollection : ILayerCollection
{
    public ObservableCollection<ILayer> ObservableItems { get; }
}
