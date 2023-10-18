using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Commands;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Application.Commands;

public class DeleteLayerCommand : ICommand
{
    private readonly ILayerCollection _layers;
    private readonly ILayer _layerToDelete;

    public DeleteLayerCommand(ILayerCollection layers, ILayer layerToDelete)
    {
        _layers = layers;
        _layerToDelete = layerToDelete;
    }

    public void Execute()
    {
        if (_layerToDelete == null) return;

        _layers.Remove(_layerToDelete);
    }

    public void Undo()
    {
        _layers.Add(_layerToDelete);
    }
}
