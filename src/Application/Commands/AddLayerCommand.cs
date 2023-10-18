using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Commands;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Application.Commands;

public class AddLayerCommand : ICommand
{
    private readonly ILayerCollection _layers;
    private readonly ILayer _newLayer;

    public AddLayerCommand(ILayerCollection layers, ILayer layer)
    {
        _layers = layers;
        _newLayer = layer;
    }

    public void Execute()
    {
        _layers.Add(_newLayer);
    }

    public void Undo()
    {
        _layers.Remove(_newLayer);
    }
}
