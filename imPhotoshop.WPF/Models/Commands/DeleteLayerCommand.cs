
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Commands;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Models.Commands;

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
