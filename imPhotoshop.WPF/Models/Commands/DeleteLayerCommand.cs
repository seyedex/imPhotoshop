
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Commands;
using imPhotoshop.WPF.Core.Interfaces.Drawing;

namespace imPhotoshop.WPF.Models.Commands;

public class DeleteLayerCommand : ICommand
{
    private readonly BindableCollection<ILayer> _layers;
    private readonly ILayer _layerToDelete;

    public DeleteLayerCommand(BindableCollection<ILayer> layers, ILayer layerToDelete)
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
