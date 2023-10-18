using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Mediators;

namespace imPhotoshop.Infrastructure.Mediators;

internal class LayerMediator : ILayerMediator
{
    public event Action<ILayer> ActiveItemChanged;

    public void ChangeActiveItem(ILayer layer)
    {
        ActiveItemChanged?.Invoke(layer);
    }
}
