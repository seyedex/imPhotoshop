
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Commands;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Models.Commands;

public class AddLayerCommand : ICommand
{
    private readonly ILayerCollection _layers;
    private ILayer _newLayer;

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
