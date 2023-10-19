using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Commands;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Application.Commands;

public class DeleteLayerCommand : ICommand
{
    private readonly ILayerCollection _layers;
    private readonly ILayer _layerToDelete;
    private readonly int _startIndex;

    public DeleteLayerCommand(ILayerCollection layers, ILayer layerToDelete)
    {
        _layers = layers;
        _layerToDelete = layerToDelete;
        _startIndex = _layers.IndexOf(_layerToDelete);
    }

    public void Execute()
    {
        if (_layerToDelete == null) return;

        _layers.Remove(_layerToDelete);
    }

    public void Undo()
    {
        _layers.Insert(_startIndex, _layerToDelete);
    }
}
